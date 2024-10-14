using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Adotion.Business.Models;

public class Adotante
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Sobrenome { get; set; }
    public string Email { get; set; }
    public Endereco Endereco { get; set; }
    
    [JsonIgnore]
    public ICollection<Animal> Animais { get; set; }
}