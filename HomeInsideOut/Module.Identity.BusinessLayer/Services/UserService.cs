using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Module.Identity.DataLayer.Data;
using Shared.BusinessLayer.Config;
using Shared.BusinessLayer.Helpers;
using Shared.BusinessLayer.Services;
using Shared.DataLayer.Models;
using Shared.Utils.Helpers;
using System.ComponentModel.DataAnnotations;

namespace Module.Identity.BusinessLayer.Services
{
    public class UserService : GenericService<User>, IUserService
    {
        private readonly JwtConfig JwtConfig;
        public UserService(IOptions<JwtConfig> jwtConfig, IMapper mapper, IdentityDbContext context) 
            : base(mapper, context)
        {
            JwtConfig = jwtConfig.Value;
        }

        public async Task<string> GenerateTokenAsync(string email, string password)
        {
            User existingUser = await dbSet.FirstOrDefaultAsync(x => x.Email == email && x.HashedPassword == password);
            
            if (existingUser == null)
            {
                ResponseHelper.ReturnUnauthorized("Authorization failed");
            }

            return TokenHelper.GenerateToken(JwtConfig, existingUser.Username, new[] { "admin" });
        }
    }
}
