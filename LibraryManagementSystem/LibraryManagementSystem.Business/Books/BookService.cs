using AutoMapper;
using LibraryManagementSystem.Business.Books.Dto;
using LibraryManagementSystem.DataAccess.Repositories;
using LibraryManagementSystem.Models.Books;

namespace LibraryManagementSystem.Business.Books
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

        public async Task<BookDto> GetByIdAsync(int id)
        {
            var book = await unitOfWork.GetRepository<Book>().GetByIdAsync(id);
            if (book == null)
            {

            }
            var response = mapper.Map<BookDto>(book);
            return response;
        }

        public async Task<BookDetailsDto> GetDetailsByIdAsync(int id)
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