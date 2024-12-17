using LibraryManagementSystem.Services.AppRoles;
using LibraryManagementSystem.Services.Books;
using LibraryManagementSystem.Services.Books.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = AppRole.Admin)]
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

            if (book == null)
                return NotFound();

            return View(book);
        }

        #region API CALLS
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<BookDto> objProductList = await service.GetAllAsync();
            return Json(new { data = objProductList });
        }
        #endregion
    }
}