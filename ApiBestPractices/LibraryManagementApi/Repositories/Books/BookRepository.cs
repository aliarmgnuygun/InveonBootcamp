namespace LibraryManagementApi.Repositories.Books
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public readonly ApplicationDbContext _dbContext;
        public BookRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
