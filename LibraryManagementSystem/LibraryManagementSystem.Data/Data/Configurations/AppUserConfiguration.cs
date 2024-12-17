using LibraryManagementSystem.Models.AppUsers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryManagementSystem.Data.Data.Configurations
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)   
        {
            builder.Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Ignore(p => p.Role);
        }
    }
}
