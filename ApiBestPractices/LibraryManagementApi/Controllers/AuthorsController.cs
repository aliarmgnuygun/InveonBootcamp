using LibraryManagementApi.Services.Authors;
using LibraryManagementApi.Services.Authors.Create;
using LibraryManagementApi.Services.Authors.Update;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;

namespace LibraryManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController(IAuthorService authorService, IDistributedCache cache) : CustomBaseController
    {
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id) => CreateActionResult(await authorService.GetByIdAsync(id));

        [HttpGet]
        public async Task<IActionResult> GetAll() => CreateActionResult(await authorService.GetAllListAsync());

        [HttpGet("{pageNumber:int}/{pageSize:int}")]
        public async Task<IActionResult> GetPagedAllList(int pageNumber, int pageSize) => CreateActionResult(await authorService.GetPagedAllListAsync(pageNumber, pageSize));

        [HttpGet("books/{id:int}")]
        public async Task<IActionResult> GetBooksWithAuthors(int id) => CreateActionResult(await authorService.GetBooksWithAuthorIdAsync(id));

        [HttpGet("books")]
        public async Task<IActionResult> GetBooksWithAuthors() => CreateActionResult(await authorService.GetBooksWithAuthorsAsync());


        [HttpPost]
        public async Task<IActionResult> Create(CreateAuthorRequest request) => CreateActionResult(await authorService.CreateAsync(request));

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, UpdateAuthorRequest request) => CreateActionResult(await authorService.UpdateAsync(id, request));

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id) => CreateActionResult(await authorService.DeleteAsync(id));
    }
}
