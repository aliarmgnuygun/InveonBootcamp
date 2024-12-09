namespace LibraryManagementApi.Repositories.Authors
{
    public interface IAuthorRepository : IRepository<Author>
    {
        Task<Author?> GetAuthorWithBooksAsync(int id);
        IQueryable<Author> GetAuthorWithBooks();
    }
}
