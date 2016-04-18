using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
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

        public async Task<TEntity> First(Expression<Func<TEntity, bool>> where = null)
        {
            if (where == null)
            {
                where = e => true;
            }

            return await Entities.FirstOrDefaultAsync(where);
        }

        public IQueryable<TEntity> FindAll(Expression<Func<TEntity, bool>> where = null)
        {
            return null != where ? Entities.Where(where) : Entities;
        }

        public async Task<int> Add(TEntity entity)
        {
            return await AddRange(entity.ToEnumerable());
        }

        public async Task<int> AddRange(IEnumerable<TEntity> entities)
        {
            Entities.AddRange(entities);
            return await DbContext.SaveChangesAsync();
        }

        public async Task<int> Update(TEntity entity)
        {
            return await UpdateRange(entity.ToEnumerable());
        }

        public async Task<int> UpdateRange(IEnumerable<TEntity> entities)
        {
            Entities.UpdateRange(entities);
            return await DbContext.SaveChangesAsync();
        }

        public async Task<int> Delete(TEntity entity)
        {
            return await DeleteRange(entity.ToEnumerable());
        }

        public async Task<int> DeleteRange(IEnumerable<TEntity> entities)
        {
            Entities.RemoveRange(entities);
            return await DbContext.SaveChangesAsync();
        }
    }
}
