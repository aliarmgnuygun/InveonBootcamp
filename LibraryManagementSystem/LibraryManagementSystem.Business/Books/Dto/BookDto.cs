namespace LibraryManagementSystem.Business.Books.Dto
{
    public record BookDto(int Id, string Title, string Author, int PublicationYear, string ISBN);
}