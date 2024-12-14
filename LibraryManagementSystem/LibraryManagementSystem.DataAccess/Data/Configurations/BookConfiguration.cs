using LibraryManagementSystem.Models.Books;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryManagementSystem.DataAccess.Data.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("Books");
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Title).IsRequired().HasMaxLength(100);
            builder.Property(b => b.Author).IsRequired().HasMaxLength(100);
            builder.Property(b => b.PublicationYear).IsRequired();
            builder.Property(b => b.ISBN).IsRequired().HasMaxLength(13);
            builder.Property(b => b.Genre).IsRequired().HasMaxLength(50);
            builder.Property(b => b.Publisher).IsRequired().HasMaxLength(100);
            builder.Property(b => b.PageCount).IsRequired();
            builder.Property(b => b.Language).IsRequired().HasMaxLength(50);
            builder.Property(b => b.Summary).HasMaxLength(500);
            builder.Property(b => b.AvailableCopies).HasDefaultValue(0);
            builder.Property(b => b.IsAvailable).HasDefaultValue(false);
            builder.Property(b => b.IsDeleted).HasDefaultValue(false);
        }
    }
}
