namespace LibraryManagementApi.Services.Books
{
    public record BookDto(int Id, string Title, int AuthorId, decimal Price);
}
