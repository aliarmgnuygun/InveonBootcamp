using LibraryManagementSystem.Services.Books.Dto;

namespace LibraryManagementSystem.Services.Books
{
    public interface IBookService
    {
        Task<BookDto> GetByIdAsync(Guid id);
        Task<BookDetailsDto> GetDetailsByIdAsync(Guid id);
        Task<List<BookDto>> GetAllAsync();

    }
}
