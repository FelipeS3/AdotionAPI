using System.Collections;
using Adotion.App.DTO.AnimalDTO;
using Adotion.Business.Interfaces;
using Adotion.Business.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Elfie.Serialization;

namespace Adotion.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdotanteController : BaseController
    {
        private readonly IEnderecoRepository _enderecoRepository;
        private readonly IAdotanteRepository _adotanteRepository;
        private readonly IMapper _mapper;

        public AdotanteController(IAdotanteRepository adotanteRepository,IMapper mapper, IEnderecoRepository enderecoRepository)
        {
            _adotanteRepository = adotanteRepository;
            _mapper = mapper;
            _enderecoRepository = enderecoRepository;
        }
        
        [HttpGet("listar/adotantes")]
        public async Task<IEnumerable> ObterTodosAdotantes()
        {
            var adotanteDto = _mapper.Map<IEnumerable<AdotanteDTO>>(await _adotanteRepository.ObterTodos());
            return(adotanteDto);
        }
        
        [HttpGet("detalhes/do/adotantes")]
        public async Task<ActionResult> Detalhes(int id)
        {
            var adotante = await _adotanteRepository.ObterAdotanteEndereco(id);
            if (adotante == null) return NotFound();           
            
            return Ok(adotante);
        }
        
        [HttpPost("adicionar/adotante")]
        public async Task<IActionResult> AddAdotante(AdotanteDTO adotanteDto)
        {
            if (!ModelState.IsValid) 
                return BadRequest(ModelState);
            var adotante = _mapper.Map<Adotante>(adotanteDto);
            await _adotanteRepository.Adicionar(adotante);
            return Ok(adotante);
        }
        [HttpGet("editar/adotante")]
        public async Task<IActionResult> Editar (int id)
        {
            var adotante = await ObterAdotanteAnimalEndereco(id);
            return Ok(adotante);
        }
        [HttpPut("editar/adotante")]
        public async Task<IActionResult> Editar (int id , AdotanteDTO adotanteDto)
        {
            if (id != adotanteDto.Id) return BadRequest();
            
            var adotante = _mapper.Map<Adotante>(adotanteDto);
            
            await _adotanteRepository.Atualizar(adotante);
            
            return Ok(adotante);
        }
        [HttpDelete("excluir-confirmar-adotante")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var adotante = _adotanteRepository.ObterAdotanteEndereco(id);
            if (adotante != null)
            {
                var enderecos = _enderecoRepository.ObterEnderecoPorAdotante(id);
                await _enderecoRepository.Remover(id);
                await _adotanteRepository.Remover(id);
            }
            return Ok("Adotante excluido com sucesso");
        }

        private async Task<AdotanteDTO> ObterAdotanteEndereco(int id)
        {
            return _mapper.Map<AdotanteDTO>(await _adotanteRepository.ObterAdotanteEndereco(id));
        }

        private async Task<AdotanteDTO> ObterAdotanteAnimalEndereco(int id)
        {
            return _mapper.Map<AdotanteDTO>(await _adotanteRepository.ObterAdotanteAnimaisEndereco(id));
        }
    }
}
