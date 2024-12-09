using AutoMapper;
using LibraryManagementApi.Repositories;
using LibraryManagementApi.Repositories.Books;
using LibraryManagementApi.Services.Books.Create;
using LibraryManagementApi.Services.Books.Update;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace LibraryManagementApi.Services.Books
{
    public class BookService(IBookRepository bookRepository, RedisCacheService cacheService, IUnitOfWork unitOfWork, IMapper mapper) : IBookService
    {

        public async Task<ServiceResult<List<BookDto>>> GetAllAsync()
        {
            var cacheKey = "books-all-list";
            var cachedData = await cacheService.GetFromCacheAsync<List<BookDto>>(cacheKey);
            if (cachedData != null)
            {
                return ServiceResult<List<BookDto>>.Success(cachedData);
            }

            var books = await bookRepository.GetAll().ToListAsync();
            if (books.Count == 0)
            {
                return ServiceResult<List<BookDto>>.Fail("No books found.", HttpStatusCode.NotFound);
            }
            var response = mapper.Map<List<BookDto>>(books);

            await cacheService.SetToCacheAsync(cacheKey, response);
            return ServiceResult<List<BookDto>>.Success(response);
        }

        public async Task<ServiceResult<BookDto>> GetByIdAsync(int id)
        {
            var cacheKey = $"book-{id}";
            var cachedData = await cacheService.GetFromCacheAsync<BookDto>(cacheKey);
            if (cachedData != null)
            {
                return ServiceResult<BookDto>.Success(cachedData);
            }
            var book = await bookRepository.Get(id);
            if (book == null)
            {
                return ServiceResult<BookDto>.Fail("Book not found.", HttpStatusCode.NotFound);
            }
            var response = mapper.Map<BookDto>(book);

            await cacheService.SetToCacheAsync(cacheKey, response);
            return ServiceResult<BookDto>.Success(response);
        }

        public async Task<ServiceResult<CreateBookResponse>> CreateAsync(CreateBookRequest request)
        {
            var book = mapper.Map<Book>(request);
            await bookRepository.AddAsync(book);
            await unitOfWork.Save();
            return ServiceResult<CreateBookResponse>.SuccessAsCreated(new CreateBookResponse(book.Id, book.Title, book.Price, book.AuthorId),
                $"api/books/{book.Id}"
            );
        }

        public async Task<ServiceResult> UpdateAsync(int id, UpdateBookRequest request)
        {
            var isBookExists = await bookRepository.Get(id);

            if (isBookExists == null)
            {
                return ServiceResult.Fail("Book not found.", HttpStatusCode.NotFound);
            }
            var book = mapper.Map<Book>(request);
            book.Id = id;
            bookRepository.Update(book);
            await unitOfWork.Save();
            return ServiceResult.Success(HttpStatusCode.NoContent);
        }

        public async Task<ServiceResult> DeleteAsync(int id)
        {
            try
            {
                var book = await bookRepository.Get(id);
                if (book == null)
                {
                    return ServiceResult.Fail("Book not found.", HttpStatusCode.NotFound);
                }
                bookRepository.Delete(book.Id);
                await unitOfWork.Save();
                return ServiceResult.Success(HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Database error occurred while deleting book.", ex);
            }
        }
    }
}
