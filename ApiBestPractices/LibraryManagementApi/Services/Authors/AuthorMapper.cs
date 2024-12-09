using AutoMapper;
using LibraryManagementApi.Repositories.Authors;
using LibraryManagementApi.Services.Authors.Create;
using LibraryManagementApi.Services.Authors.Update;

namespace LibraryManagementApi.Services.Authors
{
    public class AuthorMapper : Profile
    {
        public AuthorMapper()
        {
            CreateMap<Author, AuthorDto>().ReverseMap();
            CreateMap<Author, AuthorWithBooksDto>().ReverseMap();

            CreateMap<CreateAuthorRequest, Author>();
            CreateMap<UpdateAuthorRequest, Author>();
        }
    }
}   
