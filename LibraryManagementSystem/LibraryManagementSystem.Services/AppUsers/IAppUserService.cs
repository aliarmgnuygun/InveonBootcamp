using LibraryManagementSystem.Services.AppUsers.Dto;

namespace LibraryManagementSystem.Services.AppUsers
{
    public interface IAppUserService
    {
        Task<AppUserDto> AddToRoleAsync(AppUserDto user, string role);
        Task<AppUserDto> GetByIdAsync(string id);
        Task<List<AppUserDto>> GetAllAsync();
        Task<AppUserDto> CreateAsync(AppUserDto user);
        Task<AppUserDto> UpdateAsync(AppUserDto user,string role);
        Task<AppUserDto> RemoveRoleFromAppUserAsync(AppUserDto user, string oldRole);
        Task DeleteAsync(string id);
    }
}
