using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Shared.DataLayer.Models;
using Shared.Utils.Helpers;
using System.Linq.Expressions;

namespace Shared.BusinessLayer.Services
{
    public class GenericService<TEntity> : IGenericService<TEntity>
        where TEntity : BaseEntity
 
    {
        public IMapper mapper { get; set; }
        public DbContext dbContext { get; private set; }
        public DbSet<TEntity> dbSet { get; private set; }
        public GenericService(IMapper mapper, DbContext dbContext)
        {
            this.dbContext = dbContext;
            this.dbSet = dbContext.Set<TEntity>();
            this.mapper = mapper;
        }

        public async Task<TEntity> FindById(int id, bool detached = false, bool throwExceptionIfNotFound = false)
        {
            var user = await dbContext.Set<TEntity>().FirstOrDefaultAsync((TEntity x) => x.Id == id);
            if (throwExceptionIfNotFound && user == null) {
                ResponseHelper.ReturnNotFound($"{typeof(TEntity).ToString()} not found");
            }
            if (detached && user != null) { 
                dbContext.Entry(user).State = EntityState.Detached;
            }

            return await Task.FromResult(user);
        }

        public async Task<bool> Create(TEntity entity, bool instant = false)
        {
            dbContext.Set<TEntity>().Add(entity);
            if (instant)
            {
                await dbContext.SaveChangesAsync();
            }

            return true;
        }
        /*
        public async Task<IList<TDto>> GetByFilter(int pageIndex, int pageSize, Expression<Func<TEntity, bool>> where, Expression<Func<TEntity,>> orderBy, bool detached = false)
        {
            return mapper.Map<List<TDto>>(await Repository.GetByFilter(pageIndex, pageSize, where, orderBy, detached));
        }

        public async Task<bool> DeleteAsync(TKey id, bool throwNotFoundException = false, bool saveImmediate = false)
        {
            return await Repository.DeleteAsync(id, throwNotFoundException, saveImmediate);
        }

        public async Task<bool> DeleteManyAsync(IEnumerable<TEntity> entities, bool saveImmediate = false)
        {
            return await Repository.DeleteManyAsync(entities, saveImmediate);
        }

        public async Task<bool> UpdateAsync(TEntity entity, bool saveImmediate = false)
        {
            return await Repository.UpdateAsync(entity, saveImmediate);
        }

        public async Task<bool> UpdateManyAsync(IEnumerable<TEntity> entities, bool saveImmediate = false)
        {
            return await Repository.UpdateManyAsync(entities, saveImmediate);
        }*/
    }
}
