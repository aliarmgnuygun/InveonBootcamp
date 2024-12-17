using System.Linq.Expressions;

namespace LibraryManagementSystem.Data.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<bool> AnyAsync(Guid id);
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);

        Task<List<T>> GetAllAsync();
        Task<List<T>> GetAllPagedAsync(int pageNumber, int pageSize);
        ValueTask<T?> GetByIdAsync(Guid id);
        ValueTask<T?> GetByIdAsync(string id);

        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}