namespace LibraryManagementApi.Services.Books.Update
{
    public record UpdateBookRequest(string Title, decimal Price, int AuthorId);
}
