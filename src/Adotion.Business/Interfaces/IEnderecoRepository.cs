using Adotion.Business.Models;

namespace Adotion.Business.Interfaces;

public interface IEnderecoRepository : IRepository<Endereco>
{
    Task<Endereco> ObterEnderecoPorAdotante(int adotanteId);
}