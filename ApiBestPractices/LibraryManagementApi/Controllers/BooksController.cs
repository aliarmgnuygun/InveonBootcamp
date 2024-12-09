using LibraryManagementApi.Services.Books;
using LibraryManagementApi.Services.Books.Create;
using LibraryManagementApi.Services.Books.Update;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController(IBookService _bookService) : CustomBaseController
    {

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id) => CreateActionResult(await _bookService.GetByIdAsync(id));

        [HttpGet]
        public async Task<IActionResult> GetAll() => CreateActionResult(await _bookService.GetAllAsync());

        [HttpPost]
        public async Task<IActionResult> Create(CreateBookRequest request) => CreateActionResult(await _bookService.CreateAsync(request));

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, UpdateBookRequest request) => CreateActionResult(await _bookService.UpdateAsync(id, request));

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id) => CreateActionResult(await _bookService.DeleteAsync(id));
        
    }
}
