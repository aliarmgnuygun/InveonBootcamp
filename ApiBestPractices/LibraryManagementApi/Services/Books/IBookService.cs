using LibraryManagementApi.Services.Books.Create;
using LibraryManagementApi.Services.Books.Update;

namespace LibraryManagementApi.Services.Books
{
    public interface IBookService
    {
        Task<ServiceResult<BookDto>> GetByIdAsync(int id);
        Task<ServiceResult<List<BookDto>>> GetAllAsync();
        Task<ServiceResult<CreateBookResponse>> CreateAsync(CreateBookRequest request);
        Task<ServiceResult> UpdateAsync(int id, UpdateBookRequest request);
        Task<ServiceResult> DeleteAsync(int id);

    }
}
