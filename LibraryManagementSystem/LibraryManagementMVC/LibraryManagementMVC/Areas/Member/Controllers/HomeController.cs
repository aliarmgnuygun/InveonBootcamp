using LibraryManagementMVC.Models;
using LibraryManagementSystem.Services.Books;
using LibraryManagementSystem.Services.Books.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LibraryManagementMVC.Areas.Member.Controllers
{
    [Area("Member")]
    public class HomeController(IBookService service) : Controller
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

        [Authorize]
        public async Task<IActionResult> Lend(Guid id)
        {
            await service.LendBookAsync(id);
            return RedirectToAction("Index");
        }

        [Authorize]
        public async Task<IActionResult> Return(Guid id)
        {
            await service.ReturnBookAsync(id);
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<BookDto> objProductList = await service.GetAllAsync();
            return Json(new { data = objProductList });
        }
    }
}
