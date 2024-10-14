using Adotion.App.DTO.AnimalDTO;
using Adotion.Business.Interfaces;
using Adotion.Business.Models;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace Adotion.App.Controllers
{
    [Route("api/Animais")]
    [ApiController]
    public class AnimalController : BaseController
    {
        private readonly IAdotanteRepository _adotanteRepository;
        private readonly IAnimalRepository _animalRepository;
        private readonly IMapper _mapper;

        public AnimalController(IAnimalRepository animalRepository, IMapper mapper, IAdotanteRepository adotanteRepository)
        {
            _adotanteRepository = adotanteRepository;
            _animalRepository = animalRepository;
            _mapper = mapper;
        }
        
        [HttpGet("obter-todos-animais")]
        public async Task<ActionResult<IEnumerable<Animal>>> ObterAnimais()
        {
            var animais = _mapper.Map<IEnumerable<AnimalDTO>>(await _animalRepository.ObterAnimaisEAdotantes());
            return Ok(animais);
        }   
       
        [HttpGet("obter-animal-id")]
        public async Task<ActionResult<Animal>> ObterAnimalId(int id)
        {
            var animal = await _animalRepository.ObterPorId(id);
            return Ok(animal);
        }
        
        [HttpPost("adicionar-animais")]
        public async Task<IActionResult> AdicionarAnimal(AnimalDTO animalDto)
        {
            animalDto = await PopularAdotantes(animalDto);
            if (!ModelState.IsValid) return BadRequest(animalDto);

            var imgPrefixo = Guid.NewGuid() + "_";
            if (!await UploadArquivo(animalDto.ImagemUpload, imgPrefixo)) return Ok(animalDto);
            
            await _animalRepository.Adicionar(_mapper.Map<Animal>(animalDto));
            
            return Ok(animalDto); 
        }
        
        [HttpPut("{id}/Atualizar")] 
        public async Task<IActionResult> Put(int id, AnimalDTO animalDto)
        { 
            if (id != animalDto.Id) return BadRequest();
            
            if (!ModelState.IsValid) return BadRequest(animalDto);
            
            await _animalRepository.Atualizar(_mapper.Map<Animal>(animalDto));
            
            return Ok(animalDto);
        }

        
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var animal = await ObterAnimal(id);
            if (animal == null) return NotFound();
            
            await _animalRepository.Remover(id);
            return Ok("Removido com sucesso!");
        }

        private async Task<AnimalDTO> ObterAnimal(int id)
        {
            var animal = _mapper.Map<AnimalDTO>(await _animalRepository.ObterAnimalPorAdotante(id));
            animal.Adotantes = _mapper.Map<IEnumerable<AdotanteDTO>>(await _adotanteRepository.ObterTodos());
            return animal;
        }

        private async Task<AnimalDTO> PopularAdotantes(AnimalDTO animal) 
        {
            animal.Adotantes = _mapper.Map<IEnumerable<AdotanteDTO>>(await _adotanteRepository.ObterTodos());
            return animal;
        }

        private async Task<bool> UploadArquivo(IFormFile arquivo, string imgPrefixo)
        {
            if (arquivo.Length <= 0) return false;
            var path = Path.Combine(Directory.GetCurrentDirectory(),
                "C:\\Users\\felip\\RiderProjects\\ClassLibrary1\\src\\Adotion.Data\\Imagem", imgPrefixo + arquivo.FileName);

            if (System.IO.File.Exists(path))
            {
                ModelState.AddModelError(string.Empty, "Já existe um arquivo com esse nome!");
                return false;
            }

            using (var stream = new FileStream(path, FileMode.Create))
                {
                    await arquivo.CopyToAsync(stream);
                }
            
            return true;
        }
    }
}
