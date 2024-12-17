namespace LibraryManagementSystem.Models
{
    public abstract class BaseEntity
    {
        public Guid Id { get; init; } = Guid.NewGuid();
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