using Adotion.Business.Models;

namespace Adotion.Business.Interfaces;

public interface IAdotanteRepository : IRepository<Adotante>
{
    Task<Adotante> ObterAdotanteEndereco(int id);
    Task<Adotante> ObterAdotanteAnimaisEndereco(int id);
    
}