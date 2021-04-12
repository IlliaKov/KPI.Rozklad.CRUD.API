using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Rozklad.CRUD.BLL.Services.Interfaces
{
    public interface IGenericService<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task CreateAsync(TEntity entity);
        Task<bool> DeleteAsync(Guid id);
        Task<bool> UpdateAsync(TEntity entity);
        Task<TEntity> GetByIdAsync(Guid id);
        Task<int> CountAllAsync();
    }
}
