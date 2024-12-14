using System.Linq.Expressions;

namespace LibraryManagementSystem.DataAccess.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<bool> AnyAsync(int id);
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);

        Task<List<T>> GetAllAsync();
        Task<List<T>> GetAllPagedAsync(int pageNumber, int pageSize);
        ValueTask<T?> GetByIdAsync(int id);

        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}