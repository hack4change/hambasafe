using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Hambasafe.DataAccess
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll();
        bool Any(Expression<Func<TEntity, bool>> where = null);
        TEntity FindOne(Expression<Func<TEntity, bool>> where = null);
        IQueryable<TEntity> FindAll(Expression<Func<TEntity, bool>> where = null);
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        IQueryable<TEntity> Items { get; }
    }
    public class EfRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public DbContext DbContext { get; }

        public DbSet<TEntity> Entities => DbContext.Set<TEntity>();

        public EfRepository(DbContext dbContext)
        {
            DbContext = dbContext;
        }

        public IQueryable<TEntity> Items => Entities;

        public void Add(TEntity entity)
        {
            Entities.Add(entity);
            DbContext.SaveChanges();
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            Entities.AddRange(entities);
            DbContext.SaveChanges();
        }

        public bool Any(Expression<Func<TEntity, bool>> where = null)
        {
            return Entities.Any(where);
        }

        public void Delete(TEntity entity)
        {
            Entities.Remove(entity);
            DbContext.SaveChanges();
        }

        public IQueryable<TEntity> FindAll(Expression<Func<TEntity, bool>> where = null)
        {
            return null != where ? Entities.Where(where) : Entities;
        }

        public TEntity FindOne(Expression<Func<TEntity, bool>> where = null)
        {
            return FindAll(where).FirstOrDefault();
        }

        public IQueryable<TEntity> GetAll()
        {
            return Items.AsQueryable();
        }

        public void Update(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            Entities.Update(entity);
            DbContext.SaveChanges();
        }
    }
}
