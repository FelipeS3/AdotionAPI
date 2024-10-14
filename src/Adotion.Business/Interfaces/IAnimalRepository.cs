using Adotion.Business.Models;

namespace Adotion.Business.Interfaces;

public interface IAnimalRepository : IRepository<Animal>
{
    Task<IEnumerable<Animal>> ObterAnimaisPorAdotante(int adotanteId);
    Task<IEnumerable<Animal>> ObterAnimaisEAdotantes();
    Task<Animal> ObterAnimalPorAdotante(int id);
    Task<List<Animal>> ObterAnimalPorEspecie(string especie);
    Task<List<Animal>> ObterAnimalPorRaca(string raca);
}