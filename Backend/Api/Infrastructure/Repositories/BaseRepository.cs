using Infrastructure.DataAccess;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<T> _entity;

        public BaseRepository(ContactDbContext dbContext)
        {
            _dbContext = dbContext;
            _entity = dbContext.Set<T>();
        }

        public async Task<T> Add(T item)
        {
            await _entity.AddAsync(item);
            return item;
        }

        public T Update(T item)
        {
            _entity.Update(item);
            return item;
        }

        public void Delete(T item)
        {
            _entity.Remove(item);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _entity.AsNoTracking().ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _entity.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<T> GetByQuery(Expression<Func<T, bool>> predicate)
        {
            return await _entity.AsNoTracking().FirstOrDefaultAsync(predicate);
        }

        public async Task SaveChanges()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}