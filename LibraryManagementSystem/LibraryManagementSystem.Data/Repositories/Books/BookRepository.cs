using LibraryManagementSystem.Data.Data;
using LibraryManagementSystem.Models.Books;

namespace LibraryManagementSystem.Data.Repositories.Books
{
    public class BookRepository(ApplicationDbContext context) : GenericRepository<Book>(context), IBookRepository
    {

    }
}
