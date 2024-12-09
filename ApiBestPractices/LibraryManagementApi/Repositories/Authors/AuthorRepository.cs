using Microsoft.EntityFrameworkCore;

namespace LibraryManagementApi.Repositories.Authors
{
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {
        public readonly ApplicationDbContext _dbContext;
        public AuthorRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<Author> GetAuthorWithBooks()
        {
            return _dbContext.Authors.Include(x => x.Books).AsQueryable();
        }

        public Task<Author?> GetAuthorWithBooksAsync(int id)
        {
            return _dbContext.Authors.Include(x => x.Books).FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
