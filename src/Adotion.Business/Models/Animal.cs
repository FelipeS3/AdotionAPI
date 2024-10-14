using System.Net.Mime;
using System.Text.Json.Serialization;

namespace Adotion.Business.Models;
public class Animal
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Especie { get; set; }
    public string Raca { get; set; }
    
    public int Idade { get; set; }
    
    public string? NecessidadesEspeciais { get; set; }
    
    public bool Castrado { get; set; }
    public bool Vacinado  { get; set; }
    public Genero Genero { get; set; }
    public string? Descricao { get; set; }
    
    public bool Disponivel { get; set; }
    public string Imagem { get; set; }
    
    /* EF Relations */
    public int AdotanteId { get; set; }
    public Adotante Adotante { get; set; }
    
}
