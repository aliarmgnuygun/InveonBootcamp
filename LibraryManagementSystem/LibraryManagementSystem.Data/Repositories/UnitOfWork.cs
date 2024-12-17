using LibraryManagementSystem.Data.Data;

namespace LibraryManagementSystem.Data.Repositories
{
    public class UnitOfWork(ApplicationDbContext context) : IUnitOfWork
    {
        public IGenericRepository<T> GetRepository<T>() where T : class
        {
            return new GenericRepository<T>(context);
        }

        public Task<int> SaveChangesAsync() => context.SaveChangesAsync();

    }
}