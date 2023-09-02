using Module.Identity.BusinessLayer.DTOs;
using Shared.BusinessLayer.Services;
using Shared.DataLayer.Models;

namespace Module.Identity.BusinessLayer.Services
{
    public interface IUserService : IGenericService<UserDTO, User, int>
    {
        public Task<string> GenerateTokenAsync(string username, string password);
    }
}