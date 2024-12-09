using LibraryManagementApi.Services.Authors.Create;
using LibraryManagementApi.Services.Authors.Update;

namespace LibraryManagementApi.Services.Authors
{
    public interface IAuthorService
    {
        Task<ServiceResult<AuthorDto>> GetByIdAsync(int id);
        Task<ServiceResult<List<AuthorDto>>> GetAllListAsync();
        Task<ServiceResult<List<AuthorDto>>> GetPagedAllListAsync(int pageNumber, int pageSize);
        Task<ServiceResult<AuthorWithBooksDto>> GetBooksWithAuthorIdAsync(int authorId);
        Task<ServiceResult<List<AuthorWithBooksDto>>> GetBooksWithAuthorsAsync();
        
        Task<ServiceResult<int>> CreateAsync(CreateAuthorRequest request);
        Task<ServiceResult> UpdateAsync(int id, UpdateAuthorRequest request);
        Task<ServiceResult> DeleteAsync(int id);
    }
}
