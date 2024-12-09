using LibraryManagementApi.Repositories.Authors;

namespace LibraryManagementApi.Repositories.Books
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = default!;
        public decimal Price { get; set; }

        public int AuthorId { get; set; }
        public Author Author { get; set; } = default!;
    }
}
