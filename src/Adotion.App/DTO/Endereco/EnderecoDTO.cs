using System.ComponentModel.DataAnnotations;
using Adotion.Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace Adotion.App.DTO.AnimalDTO;

public class EnderecoDTO
{
    [Key]
    public int Id { get; set; }
    //Logradouro
    [Required(ErrorMessage = "O campo {0} precisa ser preenchido!")]
    [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {1} e {2} caracteres!", MinimumLength = 1)]
    public string Logradouro { get; set; }
    
    //Numero
    [Required(ErrorMessage = "O campo {0} precisa ser preenchido!")]
    [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {1} e {2} caracteres!", MinimumLength = 1)]
    public string Numero { get; set; }
    
    //Complemento
    [StringLength(1000, ErrorMessage = "O campo {0} precisa ter entre {1} e {2} caracteres!", MinimumLength = 1)]
    public string Complemento { get; set; }
    
    //Bairro
    [Required(ErrorMessage = "O campo {0} precisa ser preenchido!")]
    [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {1} e {2} caracteres!", MinimumLength = 1)]
    public string Bairro { get; set; }
    
    //Cidade
    [Required(ErrorMessage = "O campo {0} precisa ser preenchido!")]
    [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {1} e {2} caracteres!", MinimumLength = 1)]
    public string Cidade { get; set; }
    
    //Estado
    [Required(ErrorMessage = "O campo {0} precisa ser preenchido!")]
    [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {1} e {2} caracteres!", MinimumLength = 1)]
    public string Estado { get; set; }
    
    //Cep
    [Required(ErrorMessage = "O campo {0} precisa ser preenchido!")]
    [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {1} e {2} caracteres!", MinimumLength = 1)]
    public string Cep { get; set; }
    [HiddenInput]
    public int AdotanteId { get; set; }
}