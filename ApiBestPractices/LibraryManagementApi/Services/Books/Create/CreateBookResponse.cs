namespace LibraryManagementApi.Services.Books.Create
{
    public record CreateBookResponse(int Id, string Title, decimal Price, int AuthorId);
}
