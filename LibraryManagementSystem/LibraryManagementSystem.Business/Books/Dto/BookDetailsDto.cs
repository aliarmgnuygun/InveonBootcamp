namespace LibraryManagementSystem.Business.Books.Dto
{
    public record BookDetailsDto(int Id, string Title, string Author, int PublicationYear, string ISBN, string Genre, string Publisher, int PageCount, string Language, string Summary, int AvailableCopies);
}