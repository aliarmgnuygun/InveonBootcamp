using LibraryManagementSystem.DataAccess.Data;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.DataAccess.Repositories
{
    public class UnitOfWork(ApplicationDbContext context) : IUnitOfWork
    {
        public IGenericRepository<T> GetRepository<T>() where T : BaseEntity
        {
            return new GenericRepository<T>(context);
        }

        public Task<int> SaveChangesAsync() => context.SaveChangesAsync();

    }
}