using Bulky.Models;

namespace Bulky.DataAccess.Repository.IRepository
{
    public interface IApplicationUserRepository
    {
        ApplicationUser GetUserById(string userId);

        // Other methods you might need for ApplicationUser management
    }
}
