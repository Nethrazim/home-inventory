using AutoMapper;
using HomeInsideOut.Common.DataLayer.Repositories;
using System.Linq.Expressions;

namespace HomeInsideOut.Common.BusinessLayer.Services
{
    public interface IGenericService<TDto, TEntity, TKey>
        where TDto : class
        where TEntity : class
        where TKey : struct
    {

        public IMapper mapper { get; set; }
        public IGenericRepository<TEntity, TKey> Repository { get; set; }

        public Task<TDto> FindById(TKey id, bool detached = false, bool throwExceptionIfNotFound = false);

        public Task<IList<TDto>> GetByFilter(int pageIndex, int pageSize, Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TKey>> orderBy, bool detached = false);

        public Task<bool> DeleteAsync(TKey id, bool throwNotFoundException = false, bool saveImmediate = false);

        public Task<bool> DeleteManyAsync(IEnumerable<TEntity> entities, bool saveImmediate = false);

        public Task<bool> UpdateAsync(TEntity entity, bool saveImmediate = false);

        public Task<bool> UpdateManyAsync(IEnumerable<TEntity> entities, bool saveImmediate = false);
    }
}