namespace LibraryManagementSystem.Services.Books.Dto
{
    public record BookDetailsDto(Guid Id, string Title, string Author, int PublicationYear, string ISBN, string Genre, string Publisher, int PageCount, string Language, string Summary, int AvailableCopies);
}