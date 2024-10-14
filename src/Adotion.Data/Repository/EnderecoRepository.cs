using Adotion.Business.Interfaces;
using Adotion.Business.Models;
using Adotion.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Adotion.Data.Repository;

public class EnderecoRepository : Repository<Endereco>, IEnderecoRepository
{
    public EnderecoRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<Endereco> ObterEnderecoPorAdotante(int adotanteId)
    {
        return await Db.Enderecos.AsNoTracking().FirstOrDefaultAsync(a => a.Id == adotanteId);
    }
}