using AutoMapper;
using LibraryManagementSystem.Models.Books;
using LibraryManagementSystem.Services.Books.Dto;

namespace LibraryManagementSystem.Services.Books
{
    public class BookMappingProfile : Profile
    {
        public BookMappingProfile()
        {

            CreateMap<Book, BookDto>().ReverseMap();
            CreateMap<Book, BookDetailsDto>().ReverseMap();

        }
    }
}