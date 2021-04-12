using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Rozklad.CRUD.DAL.Repositories.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);//??
        TEntity GetById(object manufactureId);

        void Add(TEntity obj);
        void Update(TEntity obj);
        void Delete(object manufactureId);
        void Save();

    }
}
