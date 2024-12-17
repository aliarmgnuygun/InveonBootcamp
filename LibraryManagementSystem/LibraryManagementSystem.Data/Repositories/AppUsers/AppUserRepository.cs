using LibraryManagementSystem.Data.Data;
using LibraryManagementSystem.Models.AppUsers;

namespace LibraryManagementSystem.Data.Repositories.AppUsers
{
    public class AppUserRepository(ApplicationDbContext context) : GenericRepository<AppUser>(context), IAppUserRepository
    {
    }
}
