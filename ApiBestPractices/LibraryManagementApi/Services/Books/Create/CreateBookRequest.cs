namespace LibraryManagementApi.Services.Books.Create
{
    public record CreateBookRequest(string Title, decimal Price, int AuthorId);
}
