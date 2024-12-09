using LibraryManagementApi.Repositories.Authors;
using LibraryManagementApi.Repositories.Books;

namespace LibraryManagementApi.Repositories
{
    public interface IUnitOfWork
    {
        IAuthorRepository Authors { get; }
        IBookRepository Book { get; }
        Task Save();
    }
}
