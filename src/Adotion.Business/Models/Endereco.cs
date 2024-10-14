using System.Text.Json.Serialization;

namespace Adotion.Business.Models;

public class Endereco
{
    public int Id { get; set; }
    public string Logradouro { get; set; }
    public string Numero { get; set; }
    public string Complemento { get; set; }
    public string Bairro { get; set; }
    public string Cidade { get; set; }
    public string Estado { get; set; }
    public string Cep { get; set; }
    
    
    /* Ef Relations */
    public int AdotanteId { get; set; }
    [JsonIgnore]
    public Adotante Adotante { get; set; }
    
}