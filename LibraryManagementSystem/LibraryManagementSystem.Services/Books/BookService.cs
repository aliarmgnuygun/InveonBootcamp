using AutoMapper;
using LibraryManagementSystem.Data.Repositories;
using LibraryManagementSystem.Models.Books;
using LibraryManagementSystem.Services.Books.Dto;

namespace LibraryManagementSystem.Services.Books
{
    public class BookService(IUnitOfWork unitOfWork, IMapper mapper) : IBookService
    {
        public async Task<List<BookDto>> GetAllAsync()
        {
            var books = await unitOfWork.GetRepository<Book>().GetAllAsync();
            if (books.Count == 0)
            {

            }

            var response = mapper.Map<List<BookDto>>(books);
            return response;

        }

        public async Task<BookDto> GetByIdAsync(Guid id)
        {
            var book = await unitOfWork.GetRepository<Book>().GetByIdAsync(id);
            if (book == null)
            {

            }
            var response = mapper.Map<BookDto>(book);
            return response;
        }

        public async Task<BookDetailsDto> GetDetailsByIdAsync(Guid id)
        {
            var book = await unitOfWork.GetRepository<Book>().GetByIdAsync(id);
            if (book == null)
            {

            }
            var response = mapper.Map<BookDetailsDto>(book);
            return response;
        }
    }
}