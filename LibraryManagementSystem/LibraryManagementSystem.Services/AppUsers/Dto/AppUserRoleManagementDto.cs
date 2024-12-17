using LibraryManagementSystem.Models.AppUsers;
using LibraryManagementSystem.Services.AppUsers.Dto;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LibraryManagementSystem.Services.AppUsers
{
    public class AppUserRoleManagementDto
    {
        public AppUserDto AppUser { get; set; }

        public IEnumerable<SelectListItem> UserRoleList { get; set; }
    }
}