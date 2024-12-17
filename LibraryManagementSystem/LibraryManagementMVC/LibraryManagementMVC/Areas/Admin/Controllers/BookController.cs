using LibraryManagementSystem.Services.AppRoles;
using LibraryManagementSystem.Services.Books;
using LibraryManagementSystem.Services.Books.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = AppRole.Admin + "," + AppRole.Librarian)]
    public class BookController(IBookService service) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var books = await service.GetAllAsync();
            return View(books);
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var book = await service.GetDetailsByIdAsync(id);
            return View(book);
        }

        public async Task<IActionResult> Upsert(Guid id)
        {
            if (id == Guid.Empty)
            {
                return View(new BookDetailsDto(Guid.Empty, string.Empty, string.Empty, 0, string.Empty, string.Empty, string.Empty, 0, string.Empty, string.Empty, 0));
            }
            else
            {
                var book = await service.GetDetailsByIdAsync(id);
                return View(book);
            }

        }

        [HttpPost]
        public async Task<IActionResult> Upsert(BookDetailsDto bookDetailsDto)
        {
            if (ModelState.IsValid)
            {
                var book = await service.GetDetailsByIdAsync(bookDetailsDto.Id);

                if (bookDetailsDto.Id == Guid.Empty)
                {
                    await service.CreateAsync(bookDetailsDto);
                    TempData["Success"] = "Book created successfully!";
                }
                else
                {
                    await service.UpdateAsync(bookDetailsDto);
                    TempData["Success"] = "Book updated successfully!";
                }
                return RedirectToAction("Index");
            }

            return View(bookDetailsDto);
        }

        #region API CALLS
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<BookDto> objProductList = await service.GetAllAsync();
            return Json(new { data = objProductList });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            await service.DeleteAsync(id);
            return Json(new { success = true, message = "Book deleted successfully." });
        }
        #endregion
    }
}