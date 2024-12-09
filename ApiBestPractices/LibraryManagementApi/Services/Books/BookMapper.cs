using AutoMapper;
using LibraryManagementApi.Repositories.Books;
using LibraryManagementApi.Services.Books.Create;
using LibraryManagementApi.Services.Books.Update;

namespace LibraryManagementApi.Services.Books
{
    public class BookMapper : Profile
    {
        public BookMapper() { 
            
            CreateMap<Book, BookDto>().ReverseMap();

            CreateMap<CreateBookRequest, Book>();
            CreateMap<UpdateBookRequest, Book>();

            CreateMap<Book, CreateBookResponse>();  
        }
    }
}
