using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Adotion.Business.Models;
using Newtonsoft.Json;

namespace Adotion.App.DTO.AnimalDTO;

public class AnimalEdicaoDTO
{
    [Key]
    public int Id { get; set; }
    
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
    public string Imagem { get; set; }

    public AdotanteDTO? Adotante { get; set; }
}