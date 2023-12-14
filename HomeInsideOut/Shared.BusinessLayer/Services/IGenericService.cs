using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shared.DataLayer.Models;
using System.Linq.Expressions;

namespace Shared.BusinessLayer.Services
{
    public interface IGenericService<TEntity>
        where TEntity : class
    {
        public IMapper mapper { get;}
        public DbContext dbContext { get; }
        public DbSet<TEntity> dbSet { get; }
        public Task<TEntity> FindById(int id, bool detached = false, bool throwExceptionIfNotFound = false);

        public Task<bool> Create(TEntity entity, bool instant = false);
        /*
        public Task<IList<TEntity>> GetByFilter(int pageIndex, int pageSize, Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TKey>> orderBy, bool detached = false);

        public Task<bool> DeleteAsync(int id, bool throwNotFoundException = false, bool saveImmediate = false);

        public Task<bool> DeleteManyAsync(IEnumerable<TEntity> entities, bool saveImmediate = false);

        public Task<bool> UpdateAsync(TEntity entity, bool saveImmediate = false);

        public Task<bool> UpdateManyAsync(IEnumerable<TEntity> entities, bool saveImmediate = false);
        */
    }
}