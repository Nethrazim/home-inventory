using AutoMapper;
using Microsoft.Extensions.Options;
using Module.Identity.BusinessLayer.DTOs;
using Module.Identity.DataLayer.Repositories;
using Shared.BusinessLayer.Config;
using Shared.BusinessLayer.Helpers;
using Shared.BusinessLayer.Services;
using Shared.DataLayer.Models;

namespace Module.Identity.BusinessLayer.Services
{
    public class UserService : GenericService<UserDTO, User, int>, IUserService
    {
        private IUserRepository UserRepository { get; set; }
        private readonly JwtConfig JwtConfig;
        public UserService(IOptions<JwtConfig> jwtConfig, IMapper mapper, IUserRepository repository) : base(mapper, repository)
        {
            UserRepository = repository;
            JwtConfig = jwtConfig.Value;
        }

        public async Task<string> GenerateTokenAsync(string username, string password)
        {
            User existingUser = await UserRepository.Authenticate(username, password);
            return TokenHelper.GenerateToken(JwtConfig, username, new[] { "admin" });
        }
    }
}
