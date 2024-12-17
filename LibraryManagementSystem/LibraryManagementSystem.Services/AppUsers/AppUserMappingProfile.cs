using AutoMapper;
using LibraryManagementSystem.Models.AppUsers;
using LibraryManagementSystem.Services.AppUsers.Dto;

namespace LibraryManagementSystem.Services.AppUsers
{
    public class AppUserMappingProfile : Profile
    {
        public AppUserMappingProfile()
        {
            CreateMap<AppUser, AppUserDto>()
                .ForCtorParam("Email", opt => opt.MapFrom(src => src.Email))
                .ForCtorParam("FullName", opt => opt.MapFrom(src => src.Name))
                .ForCtorParam("PhoneNumber", opt => opt.MapFrom(src => src.PhoneNumber))
                .ForCtorParam("Role", opt => opt.MapFrom(src => src.Role))
                .ForCtorParam("CreatedAt", opt => opt.MapFrom(src => src.CreatedAt)).ReverseMap();

            CreateMap<AppUserRoleManagementDto, AppUser>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.AppUser.Id.ToString()))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.AppUser.Email))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.AppUser.FullName))
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.AppUser.Role))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.AppUser.CreatedAt));  
        }
    }
}