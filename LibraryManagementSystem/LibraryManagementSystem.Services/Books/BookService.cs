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
            var activeBook = books.Where(u => !u.IsDeleted).ToList();

            var response = mapper.Map<List<BookDto>>(activeBook);
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
        public async Task<BookDetailsDto> CreateAsync(BookDetailsDto bookDto)
        {
            var book = mapper.Map<Book>(bookDto);
            await unitOfWork.GetRepository<Book>().AddAsync(book);
            await unitOfWork.SaveChangesAsync();
            return mapper.Map<BookDetailsDto>(book);
        }

        public async Task<BookDetailsDto> UpdateAsync(BookDetailsDto bookDto)
        {
            var bookRepository = unitOfWork.GetRepository<Book>();
            var book = await bookRepository.GetByIdAsync(bookDto.Id);
            if (book == null)
            {
                throw new KeyNotFoundException("Book not found.");
            }

            mapper.Map(bookDto, book);
            bookRepository.Update(book);
            await unitOfWork.SaveChangesAsync();
            return mapper.Map<BookDetailsDto>(book);
        }

        public async Task DeleteAsync(Guid id)
        {
            var bookRepository = unitOfWork.GetRepository<Book>();
            var book = await bookRepository.GetByIdAsync(id);
            if (book == null)
                throw new KeyNotFoundException("Book not found.");

            book.MarkAsDeleted();

            bookRepository.Update(book);
            book.UpdateLastModified();
            await unitOfWork.SaveChangesAsync();
        }

        public async Task LendBookAsync(Guid id)
        {
            var bookRepository = unitOfWork.GetRepository<Book>();
            var book = await bookRepository.GetByIdAsync(id);
            book!.Lend();
            bookRepository.Update(book);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task ReturnBookAsync(Guid id)
        {
            var bookRepository = unitOfWork.GetRepository<Book>();
            var book = await bookRepository.GetByIdAsync(id);
            book!.Return();
            bookRepository.Update(book);
            await unitOfWork.SaveChangesAsync();
        }
    }
}