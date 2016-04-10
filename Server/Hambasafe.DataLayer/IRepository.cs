using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Hambasafe.DataLayer
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll();
        Task<TEntity> First(Expression<Func<TEntity, bool>> where = null);
        IQueryable<TEntity> FindAll(Expression<Func<TEntity, bool>> where = null);
        Task<int> Add(TEntity entity);
        Task<int> AddRange(IEnumerable<TEntity> entities);
        Task<int> Update(TEntity entity);
        Task<int> UpdateRange(IEnumerable<TEntity> entities);
        Task<int> Delete(TEntity entity);
        Task<int> DeleteRange(IEnumerable<TEntity> entities);
    }
}
