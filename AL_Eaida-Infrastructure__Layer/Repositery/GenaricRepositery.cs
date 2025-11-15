using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Al_Eaida_Domin.Interface;
namespace AL_Eaida_Infrastructure__Layer.IRepositery
{
    public class GenaricRepositery<T> : IGenaricRepositery<T> where T : class
    {
        protected readonly DbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenaricRepositery(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync(int pageNumber, int pageSize)
        {
            return await _dbSet.Skip((pageNumber - 1) * pageSize)
                                .Take(pageSize)
                                .ToListAsync();
         
        }

        public async Task<T?> GetByIdAsync(object id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<T?> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.FirstOrDefaultAsync(predicate);
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task<T> Update(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> Delete(T entity)
        {

            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        public IQueryable<T> GetQueryable()
        {
            return _dbSet.AsQueryable();
        }
    }
}
