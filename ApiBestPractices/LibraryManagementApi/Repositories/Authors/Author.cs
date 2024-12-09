using LibraryManagementApi.Repositories.Books;

namespace LibraryManagementApi.Repositories.Authors
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Email { get; set; } = default!;
        public List<Book>? Books { get; set; }
    }
}
