namespace LibraryManagementSystem.Services.AppUsers.Dto
{
    public record AppUserDto(string Id,string Email, string FullName, string PhoneNumber,string Role, DateTime CreatedAt, string IsDeleted);
}