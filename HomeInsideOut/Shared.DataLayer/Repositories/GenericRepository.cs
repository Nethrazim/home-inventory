using Microsoft.EntityFrameworkCore;
using Shared.Utils.Helpers;
using System.Linq.Expressions;

namespace Shared.DataLayer.Repositories
{
    public class GenericRepository<T, TKey> : IGenericRepository<T, TKey>
        where T : class
        where TKey : struct
    {
        public DbContext Context { get; set; }
        public DbSet<T> Set { get; set; }
        public GenericRepository(DbContext context)
        {
            Context = context;
            Set = context.Set<T>();
        }

        public async Task<T> FindById(TKey id, bool detached = false, bool throwExceptionIfNotFound = false)
        {
            T entity = await Set.FindAsync(id); ;

            if (throwExceptionIfNotFound && null == entity)
            {
                ResponseHelper.ReturnNotFound("Entity not found");
            }

            if (detached)
            {
                Context.Entry(entity).State = EntityState.Detached;
            }

            return entity;
        }

        public async Task<IList<T>> GetByFilter(int pageIndex, int pageSize, Expression<Func<T, bool>> where, Expression<Func<T, TKey>> keySelector, bool detached = false)
        {
            IQueryable<T> query = Set
                .Where(where)
                .OrderBy(keySelector)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize);

            if (detached)
            {
                query = query.AsNoTracking();
            }

            return await query.ToListAsync();
        }

        public async Task<bool> DeleteAsync(TKey id, bool throwNotFoundException = false, bool saveImmediate = false)
        {
            T entity = await Set.FindAsync(id);

            if (throwNotFoundException && entity == null)
            {
                ResponseHelper.ReturnNotFound("Entity not found");
            }

            Set.Remove(entity);

            if (saveImmediate)
            {
                await SaveChangesImmediately();
            }

            return true;
        }

        public async Task<bool> DeleteManyAsync(IEnumerable<T> entities, bool saveImmediate = false)
        {
            Set.RemoveRange(entities);

            if (saveImmediate)
            {
                await SaveChangesImmediately();
            }

            return true;
        }

        public async Task<bool> UpdateAsync(T entity, bool saveImmediate = false)
        {
            Set.Update(entity);

            if (saveImmediate)
            {
                await SaveChangesImmediately();
            }

            return true;
        }

        public async Task<bool> UpdateManyAsync(IEnumerable<T> entities, bool saveImmediate = false)
        {
            Set.UpdateRange(entities);

            if (saveImmediate)
            {
                await SaveChangesImmediately();
            }

            return true;
        }

        private async Task SaveChangesImmediately()
        {
            await Context.SaveChangesAsync();
        }

    }
}
