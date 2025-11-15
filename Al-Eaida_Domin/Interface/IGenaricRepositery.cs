using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Al_Eaida_Domin.Interface

{
    public interface IGenaricRepositery<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync(int pageNumber, int pageSize);
        Task<T?> GetByIdAsync(object id);
        Task<T?> GetAsync(System.Linq.Expressions.Expression<Func<T, bool>> predicate);
        Task AddAsync(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(T entity);
        IQueryable<T> GetQueryable();

    }
}
