using Microsoft.EntityFrameworkCore;
using Module.Identity.DataLayer.Data;
using Shared.DataLayer.Models;
using Shared.DataLayer.Repositories;
using Shared.Utils.Helpers;

namespace Module.Identity.DataLayer.Repositories
{
    public class UserRepository : GenericRepository<User, int>, IUserRepository
    {
        public UserRepository(IdentityDbContext context) : base(context)
        {

        }

        public async Task<User> Authenticate(string username, string password)
        {
            User user = await Set.Where(u => u.Username == username && u.HashedPassword == password).AsNoTracking().FirstOrDefaultAsync();

            if (user == null)
            {
                ResponseHelper.ReturnNotFound("User not found");
            }

            return user;
        }

    }
}
