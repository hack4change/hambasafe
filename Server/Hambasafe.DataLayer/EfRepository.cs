using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Hambasafe.DataLayer;
using Hambasafe.DataLayer.Entities;
using Hambasafe.DataLayer.Extensions;
using Microsoft.Data.Entity;

namespace Hambasafe.DataLayer
{
    public class EfRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private HambasafeDataContext DbContext { get; }

        private DbSet<TEntity> Entities => DbContext.Set<TEntity>();

        public EfRepository(HambasafeDataContext dbContext)
        {
            DbContext = dbContext;
        }

        public IQueryable<TEntity> GetAll()
        {
            return Entities.AsQueryable();
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

            // TODO : Return entity here with id
            AddRange(entity.ToEnumerable());
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

            UpdateRange(entity.ToEnumerable());
        }

        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            if (entities == null)
            {
                throw new ArgumentNullException(nameof(entities));
            }

            Entities.UpdateRange(entities);
            DbContext.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            DeleteRange(entity.ToEnumerable());
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
