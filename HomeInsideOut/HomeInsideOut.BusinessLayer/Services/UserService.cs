using AutoMapper;
using HomeInsideOut.BusinessLayer.DTOs;
using HomeInsideOut.Common.BusinessLayer.Services;
using HomeInsideOut.DataLayer.Models;
using HomeInsideOut.DataLayer.Repositories;
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
        public UserService(IMapper mapper, IUserRepository repository) : base(mapper, repository)
        {
            UserRepository = repository;
        }
    }
}
