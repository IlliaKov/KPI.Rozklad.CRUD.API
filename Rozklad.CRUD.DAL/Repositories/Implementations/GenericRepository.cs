using Microsoft.EntityFrameworkCore;
using Rozklad.CRUD.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Rozklad.CRUD.DAL.Repositories.Implementations
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected RozkladContext _dbContext;
        private DbSet<TEntity> dbEntity;

        public GenericRepository(RozkladContext dbContext)
        {
            _dbContext = dbContext;
            dbEntity = _dbContext.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await dbEntity.ToListAsync();
        }

        public async Task CreateAsync(TEntity entity)
        {
            await dbEntity.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var answer = await dbEntity.FindAsync(id);

            if (answer == null)
                return false;

            dbEntity.Remove(answer);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateAsync(TEntity entity)
        {
            var answer = _dbContext.Entry(entity).State;
            if (answer != EntityState.Modified)
                return false;

            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await dbEntity.FindAsync(id);
        }

        public async Task<int> CountAllAsync()
        {
            return await dbEntity.CountAsync();
        }

        public async Task<IEnumerable<TEntity>> GetWhere(Expression<Func<TEntity, bool>> predicate)
        {
            return await dbEntity.Where(predicate).ToListAsync();
        }
    }
}
