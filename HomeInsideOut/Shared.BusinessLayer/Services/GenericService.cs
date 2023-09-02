using AutoMapper;
using Shared.DataLayer.Repositories;
using System.Linq.Expressions;

namespace Shared.BusinessLayer.Services
{
    public class GenericService<TDto, TEntity, TKey> : IGenericService<TDto, TEntity, TKey>
        where TDto : class
        where TEntity : class
        where TKey : struct
    {
        public IMapper mapper { get; set; }
        public IGenericRepository<TEntity, TKey> Repository { get; set; }
        public GenericService(IMapper mapper, IGenericRepository<TEntity, TKey> repository)
        {
            Repository = repository;
            this.mapper = mapper;
        }

        public async Task<TDto> FindById(TKey id, bool detached = false, bool throwExceptionIfNotFound = false)
        {
            return mapper.Map<TDto>(await Repository.FindById(id, detached, throwExceptionIfNotFound));
        }

        public async Task<IList<TDto>> GetByFilter(int pageIndex, int pageSize, Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TKey>> orderBy, bool detached = false)
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
        }
    }
}
