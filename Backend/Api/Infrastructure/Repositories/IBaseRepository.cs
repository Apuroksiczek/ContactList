using Infrastructure.Entities;
using System.Linq.Expressions;

namespace Infrastructure.Repositories
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<T> Add(T item);
        void Delete(T item);
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task<T> GetByQuery(Expression<Func<T, bool>> predicate);
        Task SaveChanges();
        T Update(T item);
    }
}