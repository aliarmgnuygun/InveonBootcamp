using LibraryManagementApi.Repositories.Authors;
using LibraryManagementApi.Repositories.Books;

namespace LibraryManagementApi.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;
        public IBookRepository Book { get; private set; }
        public IAuthorRepository Authors { get; private set; }

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            Book = new BookRepository(_dbContext);
            Authors = new AuthorRepository(_dbContext);
        }
        public async Task Save()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
