namespace LibraryManagementSystem.Services.Books.Dto
{
    public record BookDto(Guid Id, string Title, string Author, int PublicationYear, string ISBN);
}