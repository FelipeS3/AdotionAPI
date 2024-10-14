using System.Linq.Expressions;
using Adotion.Business.Interfaces;
using Adotion.Business.Models;
using Adotion.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Adotion.Data.Repository;

public abstract class Repository<T> : IRepository<T> where T : class
{
    protected readonly AppDbContext Db;
    protected readonly DbSet<T> DbSet;

    protected Repository(AppDbContext db)
    {
        Db = db;
        DbSet = db.Set<T>();
    }

    public async Task<IEnumerable<T>> Buscar(Expression<Func<T, bool>> predicate)
    {
        return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
    }
    public virtual async Task<List<T>> ObterTodos()
    {
        return await DbSet.ToListAsync();
    }
    
    public virtual async Task<T> ObterPorId(int id)
    {
        return await DbSet.FindAsync(id);
    }
    public virtual async Task Adicionar(T entity)
    {
        DbSet.Add(entity);
        await Db.SaveChangesAsync();
    }
    public virtual async Task Atualizar(T entity)
    {
        DbSet.Update(entity);
        await Db.SaveChangesAsync();
    }

    public virtual async Task Remover(int id)
    {
        DbSet.Remove(await DbSet.FindAsync(id));
        await Db.SaveChangesAsync();  
    }
    public async Task<int> SaveChanges()
    {
        return await Db.SaveChangesAsync();
    }
    public void Dispose()
    {
        Db?.Dispose();
    }
}