using Adotion.Business.Interfaces;
using Adotion.Business.Models;
using Adotion.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Adotion.Data.Repository;

public class AnimalRepository : Repository<Animal>, IAnimalRepository
{
    public AnimalRepository(AppDbContext context) : base(context)
    {
    }
    
    public async Task<IEnumerable<Animal>> ObterAnimaisPorAdotante(int adotanteId)
    {
        return await Db.Animais
            .AsNoTracking()
            .Include(a => a.Adotante)
            .Where(a => a.AdotanteId == adotanteId)
            .ToListAsync();
    }

    public async Task<IEnumerable<Animal>> ObterAnimaisEAdotantes()
    {
        return await Db.Animais.AsNoTracking().Include(a=>a.Adotante).ToListAsync();
    }

    public async Task<Animal> ObterAnimalPorAdotante(int id)
    {
        return await Db.Animais.AsNoTracking().FirstOrDefaultAsync(a => a.Id == id);
    }

    public async Task<List<Animal>> ObterAnimalPorEspecie(string especie)
    {
        return await Db.Animais.AsNoTracking().Where(a => a.Especie == especie).ToListAsync();
    }

    public async Task<List<Animal>> ObterAnimalPorRaca(string raca)
    {
        return await Db.Animais.AsNoTracking().Where(a => a.Raca == raca).ToListAsync();
    }

    public async Task<List<Animal>> ObterTodosAnimais()
    {
        return await ObterTodos();
    }

    public async Task<Animal> ObterAnimalPorId(int id)
    {
        return await ObterPorId(id);
    }
}