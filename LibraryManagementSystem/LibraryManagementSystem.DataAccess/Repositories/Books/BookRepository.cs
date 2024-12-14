using LibraryManagementSystem.DataAccess.Data;
using LibraryManagementSystem.Models.Books;

namespace LibraryManagementSystem.DataAccess.Repositories.Books
{
    public class BookRepository(ApplicationDbContext context) : GenericRepository<Book>(context), IBookRepository
    {

    }
}
