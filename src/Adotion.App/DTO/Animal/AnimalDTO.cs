using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Adotion.Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace Adotion.App.DTO.AnimalDTO;

public class AnimalDTO
{
    [Key]
    public int Id { get; set; }
    [Required]
    [DisplayName("Adotante")]
    public int AdotanteId { get; set; }
    
    //Nome
    [Required(ErrorMessage = "O campo {0} precisa ser preenchido!")]
    [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {1} e {2} caracteres!", MinimumLength = 1)]
    public string Nome { get; set; }
    
    //Especie
    [Required(ErrorMessage = "O campo {0} precisa ser preenchido!")]
    [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {1} e {2} caracteres!", MinimumLength = 1)]
    public string Especie { get; set; }
    
    //Raca
    [Required(ErrorMessage = "O campo {0} precisa ser preenchido!")]
    [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {1} e {2} caracteres!", MinimumLength = 1)]
    public string Raca { get; set; }
    
    public int Idade { get; set; }
    
    [DisplayName("Necessidades Especiais")]
    public string? NecessidadesEspeciais { get; set; }
    
    public bool Castrado { get; set; }
    public bool Vacinado  { get; set; }
    public Genero Genero { get; set; }
    
    
    [StringLength(1000)]
    [DisplayName("Descrição")]
    public string? Descricao { get; set; }
    
    public bool Disponivel { get; set; }
    
    public IFormFile? ImagemUpload { get; set; }
    
    public string Imagem { get; set; }
    
    [JsonIgnore]
    public virtual AdotanteDTO? Adotante { get; set; }
    [JsonIgnore]
    public virtual IEnumerable<AdotanteDTO>?Adotantes { get; set; }
}