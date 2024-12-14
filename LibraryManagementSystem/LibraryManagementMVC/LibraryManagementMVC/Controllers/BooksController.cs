using LibraryManagementSystem.Business.Books;
using LibraryManagementSystem.Business.Books.Dto;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementMVC.Controllers
{
    public class BooksController(IBookService service) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var books = await service.GetAllAsync();
            return View(books);
        }

        public async Task<IActionResult> Details(int id)
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