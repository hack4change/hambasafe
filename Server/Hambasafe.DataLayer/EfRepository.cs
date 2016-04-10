using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Hambasafe.DataLayer;
using Hambasafe.DataLayer.Entities;
using Microsoft.Data.Entity;

namespace Hambasafe.DataLayer
{
    public class EfRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private HambasafeDataContext DbContext { get; }

        private DbSet<TEntity> Entities => DbContext.Set<TEntity>();

        public IQueryable<TEntity> Items => Entities;

        public EfRepository(HambasafeDataContext dbContext)
        {
            DbContext = dbContext;
        }

        public IQueryable<TEntity> GetAll()
        {
            return Items.AsQueryable();
        }

        public bool Any(Expression<Func<TEntity, bool>> where = null)
        {
            return Entities.Any(where);
        }

        public Task<TEntity> First(Expression<Func<TEntity, bool>> where = null)
        {
            return Entities.FirstAsync(where);
        }

        public IQueryable<TEntity> FindAll(Expression<Func<TEntity, bool>> where = null)
        {
            return null != where ? Entities.Where(where) : Entities;
        }

        public void Add(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            Entities.Add(entity);
            DbContext.SaveChanges();

            // TODO : Return entity here with id
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            if (entities == null)
            {
                throw new ArgumentNullException(nameof(entities));
            }

            Entities.AddRange(entities);
            DbContext.SaveChanges();

            // TODO : Return entities here with id
        }

        public void Update(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            Entities.Update(entity);
            DbContext.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            Entities.Remove(entity);
            DbContext.SaveChangesAsync();
        }

        public void DeleteRange(IEnumerable<TEntity> entities)
        {
            if (entities == null)
            {
                throw new ArgumentNullException(nameof(entities));
            }

            Entities.RemoveRange(entities);
            DbContext.SaveChangesAsync();
        }
    }
}
