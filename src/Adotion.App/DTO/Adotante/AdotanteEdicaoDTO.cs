using System.ComponentModel.DataAnnotations;
using Adotion.Business.Models;

namespace Adotion.App.DTO.AnimalDTO;

public class AdotanteEdicaoDTO
{
    [Key]
    public int Id { get; set; }
    
    public string Nome { get; set; }
    
    public string Sobrenome { get; set; }
    [EmailAddress]
    public string Email { get; set; }
    public Endereco Endereco { get; set; }
}