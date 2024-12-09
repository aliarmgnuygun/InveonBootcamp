using LibraryManagementApi.Services.Books;

namespace LibraryManagementApi.Services.Authors
{
    public record AuthorWithBooksDto(string Name, string Email, List<BookDto> Books);
}
