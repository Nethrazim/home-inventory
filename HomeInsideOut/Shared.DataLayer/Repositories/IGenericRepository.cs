using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Shared.DataLayer.Repositories
{
    public interface IGenericRepository<T, TKey>
        where T : class
        where TKey : struct
    {
        public DbContext Context { get; set; }
        public Task<T> FindById(TKey id, bool detached = false, bool throwExceptionIfNotFound = false);
        public Task<IList<T>> GetByFilter(int pageIndex, int pageSize, Expression<Func<T, bool>> where, Expression<Func<T, TKey>> keySelector, bool detached = false);
        public Task<bool> DeleteAsync(TKey id, bool throwNotFoundException = false, bool saveImmediate = false);
        public Task<bool> DeleteManyAsync(IEnumerable<T> entities, bool saveImmediate = false);
        public Task<bool> UpdateAsync(T entity, bool saveImmediate = false);
        public Task<bool> UpdateManyAsync(IEnumerable<T> entities, bool saveImmediate = false);
    }
}
