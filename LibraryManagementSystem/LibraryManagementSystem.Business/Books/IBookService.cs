using LibraryManagementSystem.Business.Books.Dto;

namespace LibraryManagementSystem.Business.Books
{
    public interface IBookService
    {
        Task<BookDto> GetByIdAsync(int id);
        Task<BookDetailsDto> GetDetailsByIdAsync(int id);
        Task<List<BookDto>> GetAllAsync();
        
    }
}
