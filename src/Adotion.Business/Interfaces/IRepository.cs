using System.Linq.Expressions;

namespace Adotion.Business.Interfaces;

public interface IRepository<T> : IDisposable where T : class
{
    Task Adicionar (T entity);
    Task<T> ObterPorId (int id);
    Task<List<T>> ObterTodos();
    Task Atualizar (T entity); 
    Task Remover (int id);
    Task<IEnumerable<T>> Buscar (Expression<Func<T, bool>> predicate);
    Task<int> SaveChanges();
}