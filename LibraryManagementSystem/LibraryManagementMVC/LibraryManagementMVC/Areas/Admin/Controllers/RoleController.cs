using LibraryManagementSystem.Services.AppRoles;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = AppRole.Admin)]
    public class RoleController(RoleManager<IdentityRole> roleManager) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var objUserList = await roleManager.Roles.ToListAsync();
            return View(objUserList);
        }

        public async Task<IActionResult> Upsert(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return View(new IdentityRole { Id = string.Empty });
            }
            else
            {
                var existingRole = await roleManager.FindByIdAsync(id);
                if (existingRole == null)
                {
                    return NotFound();
                }
                return View(existingRole);
            }
        }


        [HttpPost]
        public async Task<IActionResult> Upsert(IdentityRole role)
        {
            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(role.Id))
                {
                    var result = await roleManager.CreateAsync(new IdentityRole { Name = role.Name });
                    if (result.Succeeded)
                    {
                        TempData["Success"] = "Role created successfully";
                    }
                    else
                    {
                        TempData["Error"] = "Error creating role";
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                        return View(role);
                    }
                }
                else
                {
                    var existingRole = await roleManager.FindByIdAsync(role.Id);
                    if (existingRole == null)
                    {
                        return NotFound();
                    }

                    existingRole.Name = role.Name;
                    var result = await roleManager.UpdateAsync(existingRole);
                    if (result.Succeeded)
                    {
                        TempData["Success"] = "Role updated successfully";
                    }
                    else
                    {
                        TempData["Error"] = "Error updating role";
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                        return View(role);
                    }
                }
                return RedirectToAction("Index");
            }
            return View(role);
        }

        #region API CALLS

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var objUserList = await roleManager.Roles.ToListAsync();
            return Json(new { data = objUserList });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(IdentityRole role)
        {
            await roleManager.DeleteAsync(role);
            return Json(new { success = true, message = "User deleted successfully." });
        }
        #endregion
    }
}
