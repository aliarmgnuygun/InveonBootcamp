namespace LibraryManagementSystem.Models
{
    public abstract class BaseEntity
    {
        public int Id { get; init; } = default!;
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