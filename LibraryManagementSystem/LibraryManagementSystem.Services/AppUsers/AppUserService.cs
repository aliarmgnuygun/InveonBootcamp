using AutoMapper;
using LibraryManagementSystem.Data.Repositories;
using LibraryManagementSystem.Models.AppUsers;
using LibraryManagementSystem.Services.AppUsers.Dto;
using Microsoft.AspNetCore.Identity;

namespace LibraryManagementSystem.Services.AppUsers
{
    public class AppUserService(IUnitOfWork unitOfWork,UserManager<IdentityUser> userManager, IMapper mapper) : IAppUserService
    {
        public async Task<List<AppUserDto>> GetAllAsync()
        {
            List<AppUser> users = await unitOfWork.GetRepository<AppUser>().GetAllAsync();
            var activeUsers = users.Where(u => !u.IsDeleted).ToList();

            foreach (var user in activeUsers)
            {
                var role = await userManager.GetRolesAsync(user);
                user.Role = role.FirstOrDefault()!;
            }

            var result = mapper.Map<List<AppUserDto>>(activeUsers);
            return result;
        }

        public async Task<AppUserDto> GetByIdAsync(string id)
        {
            var user = await unitOfWork.GetRepository<AppUser>().GetByIdAsync(id);
            var role = await userManager.GetRolesAsync(user!);
            user!.Role = role.FirstOrDefault()!;
            var result = mapper.Map<AppUserDto>(user);
            return result;
        }

        public async Task<AppUserDto> CreateAsync(AppUserDto userDto)
        {
            var userEntity = mapper.Map<AppUser>(userDto);
            await unitOfWork.GetRepository<AppUser>().AddAsync(userEntity);
            await unitOfWork.SaveChangesAsync();
            return mapper.Map<AppUserDto>(userEntity);
        }

        public async Task<AppUserDto> UpdateAsync(AppUserDto userDto, string role)
        {
            var userRepository = unitOfWork.GetRepository<AppUser>();
            var existingUser = await userRepository.GetByIdAsync(userDto.Id);
            if (existingUser == null)
                throw new KeyNotFoundException("User not found.");

            mapper.Map(userDto, existingUser);
            existingUser.Role = role;

            userRepository.Update(existingUser);
            existingUser.UpdateLastModified();
            await unitOfWork.SaveChangesAsync(); 

            return mapper.Map<AppUserDto>(existingUser);
        }

        public async Task<AppUserDto> RemoveRoleFromAppUserAsync(AppUserDto userDto, string oldRole)
        {
            var userEntity = mapper.Map<AppUser>(userDto);
           
            await userManager.RemoveFromRoleAsync(userEntity, oldRole);
            await unitOfWork.SaveChangesAsync();

            return mapper.Map<AppUserDto>(userEntity);
        }

        public async Task DeleteAsync(string id)
        {
            var userRepository = unitOfWork.GetRepository<AppUser>();
            var user = await userRepository.GetByIdAsync(id);
            if (user == null)
                throw new KeyNotFoundException("User not found.");

            user.MarkAsDeleted();

            userRepository.Update(user);
            user.UpdateLastModified();
            await unitOfWork.SaveChangesAsync();
        }

        public async Task<AppUserDto> AddToRoleAsync(AppUserDto userDto, string role)
        {
            var userEntity = mapper.Map<AppUser>(userDto);
            
            await userManager.AddToRoleAsync(userEntity, role);
            await unitOfWork.SaveChangesAsync();
            
            return mapper.Map<AppUserDto>(userEntity);
        }
    }
}
