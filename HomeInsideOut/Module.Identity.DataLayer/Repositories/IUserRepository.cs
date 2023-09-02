using Shared.DataLayer.Models;
using Shared.DataLayer.Repositories;

namespace Module.Identity.DataLayer.Repositories
{
    public interface IUserRepository : IGenericRepository<User, int>
    {
        public Task<User> Authenticate(string username, string password);
    }
}
