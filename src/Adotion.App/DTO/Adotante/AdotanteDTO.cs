using System.ComponentModel.DataAnnotations;
using Adotion.Business.Models;
using Newtonsoft.Json;

namespace Adotion.App.DTO.AnimalDTO;

public class AdotanteDTO
{
    [Key]
    public int Id { get; set; }
    
    [Required(ErrorMessage = "O campo {0} precisa ser preenchido!")]
    [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {1} e {2} caracteres!", MinimumLength = 1)]
    public string Nome { get; set; }
    
    [Required(ErrorMessage = "O campo {0} precisa ser preenchido!")]
    [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {1} e {2} caracteres!", MinimumLength = 1)]
    public string Sobrenome { get; set; }
    
    [EmailAddress]
    [Required(ErrorMessage = "O campo {0} precisa ser preenchido!")]
    
    public string Email { get; set; }
    
    public EnderecoDTO Endereco { get; set; }
    
    [JsonIgnore]
    public List<AnimalDTO> Animais { get; set; }
}