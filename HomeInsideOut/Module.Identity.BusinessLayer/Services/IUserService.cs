using Module.Identity.BusinessLayer.DTOs;
using Shared.BusinessLayer.Services;
using Shared.DataLayer.Models;

namespace Module.Identity.BusinessLayer.Services
{
    public interface IUserService : IGenericService<User>
    {
        public Task<string> GenerateTokenAsync(string username, string password);
        public Task<bool> CreateAccountAsync(string username, string email, string password);
    }
}