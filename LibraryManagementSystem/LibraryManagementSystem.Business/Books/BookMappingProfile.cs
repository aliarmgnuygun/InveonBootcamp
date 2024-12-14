using AutoMapper;
using LibraryManagementSystem.Business.Books.Dto;
using LibraryManagementSystem.Models.Books;

namespace LibraryManagementSystem.Business.Books
{
    public class BookMappingProfile : Profile
    {
        public BookMappingProfile() 
        {
            
            CreateMap<Book,BookDto>().ReverseMap();
            CreateMap<Book, BookDetailsDto>().ReverseMap();

        }
    }
}