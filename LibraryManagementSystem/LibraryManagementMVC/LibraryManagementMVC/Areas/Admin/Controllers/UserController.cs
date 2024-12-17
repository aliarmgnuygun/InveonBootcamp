using LibraryManagementSystem.Models.AppUsers;
using LibraryManagementSystem.Services.AppRoles;
using LibraryManagementSystem.Services.AppUsers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = AppRole.Admin)]
    public class UserController(IAppUserService userService, RoleManager<IdentityRole> roleManager) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> RoleManagement(string id)
        {
            var userDto = await userService.GetByIdAsync(id);
            var userRoleList = await roleManager.Roles
                .Select(role => new SelectListItem
                {
                    Text = role.Name,
                    Value = role.Name
                })
                .ToListAsync();

            AppUserRoleManagementDto userUpsertDto = new AppUserRoleManagementDto()
            {
                AppUser = userDto,               
                UserRoleList = userRoleList
            };

            return View(userUpsertDto);
        }

        [HttpPost]
        public async Task<IActionResult> RoleManagement(AppUserRoleManagementDto appUserDto)
        {
            var existUser = await userService.GetByIdAsync(appUserDto.AppUser.Id);
            string oldRole = existUser.Role;


            if (!(appUserDto.AppUser.Role == oldRole))
            {
                await userService.UpdateAsync(existUser, appUserDto.AppUser.Role);
                await userService.RemoveRoleFromAppUserAsync(existUser, oldRole);
                await userService.AddToRoleAsync(existUser, appUserDto.AppUser.Role);
            }
            else
            {
                await userService.UpdateAsync(existUser, oldRole);
            }
            return RedirectToAction("Index");
        }

        #region API CALLS

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var objUserList = await userService.GetAllAsync();
            return Json(new { data = objUserList });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            await userService.DeleteAsync(id);
            return Json(new { success = true, message = "User deleted successfully." });
        }

        //[HttpPost]
        //public async Task<IActionResult> Create([FromBody] AppUserDto newUser)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        await userService.CreateAsync(newUser);
        //        return Json(new { success = true, message = "User created successfully." });
        //    }
        //    return Json(new { success = false, message = "Invalid user data." });
        //}

        #endregion
    }
}
