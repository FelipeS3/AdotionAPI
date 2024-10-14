using Adotion.Business.Interfaces;
using Adotion.Business.Models;
using Adotion.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Adotion.Data.Repository;

public class AdotanteRepository : Repository<Adotante>, IAdotanteRepository
{
    public AdotanteRepository(AppDbContext context) : base(context) 
    { }
    public async Task<Adotante> ObterAdotanteEndereco(int id)
    {
        return await Db.Adotantes
            .Include(a => a.Endereco)
            .AsNoTracking()
            .FirstOrDefaultAsync(a => a.Id == id);
    }

    public async Task<Adotante> ObterAdotanteAnimaisEndereco(int id)
    {
        return await Db.Adotantes.AsNoTracking()
            .Include(a => a.Animais)
            .Include(a => a.Endereco).FirstOrDefaultAsync(a=>a.Id == id);
    }
    
}