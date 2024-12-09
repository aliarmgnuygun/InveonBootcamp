namespace LibraryManagementApi.Services.Books.Update
{
    public record UpdateBookResponse(int Id, string Title, decimal Price, int AuthorId);
}
