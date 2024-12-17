using LibraryManagementSystem.Services.Books.Dto;

namespace LibraryManagementSystem.Services.Books
{
    public interface IBookService
    {
        Task<BookDto> GetByIdAsync(Guid id);
        Task<BookDetailsDto> GetDetailsByIdAsync(Guid id);
        Task<List<BookDto>> GetAllAsync();

        Task<BookDetailsDto> CreateAsync(BookDetailsDto bookDto);
        Task<BookDetailsDto> UpdateAsync(BookDetailsDto bookDto);
        Task DeleteAsync(Guid id);
        Task LendBookAsync(Guid id);
        Task ReturnBookAsync(Guid id);
    }
}
