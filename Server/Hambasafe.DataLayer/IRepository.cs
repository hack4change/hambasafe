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
        bool Any(Expression<Func<TEntity, bool>> where = null);
        Task<TEntity> First(Expression<Func<TEntity, bool>> where = null);
        IQueryable<TEntity> FindAll(Expression<Func<TEntity, bool>> where = null);
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void DeleteRange(IEnumerable<TEntity> entities);
        IQueryable<TEntity> Items { get; }
    }
}
