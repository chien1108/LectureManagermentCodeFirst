using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LecturerManagement.Core.Contracts
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IList<T>> FindAllAsync(
            Expression<Func<T, bool>> expression = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            List<string> includes = null
            );
        Task<T> FindByConditionAsync(Expression<Func<T, bool>> expression, List<string> includes = null);
        Task<bool> IsExistsAsync(Expression<Func<T, bool>> expression = null);
        Task Create(T entity);
        void Update(T entity);
        void Delete(T entity);

        Task<bool> Save();
    }
}
