using Microsoft.AspNetCore.Identity;

namespace LibraryManagementSystem.Models.AppUsers
{
    public class AppUser : IdentityUser
    {
        public string Name { get; set; } = default!;

        public string Role { get; set; } = default!;

        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; private set; }
        public bool IsDeleted { get; private set; } = false;


        public void MarkAsDeleted()
        {
            IsDeleted = true;
        }

        public void MarkAsNotDeleted()
        {
            IsDeleted = false;
        }

        public void UpdateLastModified()
        {
            UpdatedAt = DateTime.UtcNow;
        } 
    }
}