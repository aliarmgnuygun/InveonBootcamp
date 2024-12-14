using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.DataAccess.Repositories
{
    public interface IUnitOfWork
    {
        IGenericRepository<T> GetRepository<T>() where T : BaseEntity;
        Task<int> SaveChangesAsync();
    }
}
