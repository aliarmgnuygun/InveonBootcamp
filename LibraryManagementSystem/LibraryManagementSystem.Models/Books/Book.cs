namespace LibraryManagementSystem.Models.Books
{
    public class Book : BaseEntity
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int PublicationYear { get; set; }
        public string ISBN { get; set; }
        public string Genre { get; set; }
        public string Publisher { get; set; }
        public int PageCount { get; set; }
        public string Language { get; set; }
        public string Summary { get; set; }
        public int AvailableCopies { get; set; }
        public bool IsAvailable { get; private set; }

        private Book()
        {
        }

        public Book(string title, string author, int publicationYear, string isbn, string genre, string publisher, int pageCount, string language)
        {
            Title = title;
            Author = author;
            PublicationYear = publicationYear;
            ISBN = isbn;
            Genre = genre;
            Publisher = publisher;
            PageCount = pageCount;
            Language = language;
            Summary = string.Empty;
            AvailableCopies = 0;
            UpdateAvailabilityStatus();
        }
    

        // Lend means that the book is lent to a user, so the AvailableCopies property should be decremented by one.
        public void Lend()
        {
            if (!IsAvailable)
                throw new InvalidOperationException("Cannot lend a book when no copies are available.");

            AvailableCopies--;
            UpdateAvailabilityStatus();
            UpdateLastModified();
        }

        // Return means that the book is returned to the library, so the AvailableCopies property should be incremented by one.
        public void Return()
        {
            AvailableCopies++;
            UpdateAvailabilityStatus();
            UpdateLastModified();
        }

        // UpdateAvailabilityStatus means that the IsAvailable property should be updated based on the AvailableCopies property.
        private void UpdateAvailabilityStatus()
        {
            IsAvailable = AvailableCopies > 0;
        }
    }    
}