using AutoMapper;
using HomeInsideOut.BusinessLayer.Config;
using HomeInsideOut.BusinessLayer.DTOs;
using HomeInsideOut.BusinessLayer.Helpers;
using HomeInsideOut.Common.BusinessLayer.Services;
using HomeInsideOut.DataLayer.Models;
using HomeInsideOut.DataLayer.Repositories;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeInsideOut.BusinessLayer.Services
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
            return TokenHelper.GenerateToken(JwtConfig, username, new[] { "admin" } );
        }
    }
}
