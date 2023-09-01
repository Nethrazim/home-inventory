using AutoMapper;
using HomeInsideOut.Common.DataLayer.Repositories;
using HomeInsideOut.DataLayer.Data;
using HomeInsideOut.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeInsideOut.DataLayer.Repositories
{
    public class UserRepository : GenericRepository<User, int>, IUserRepository
    {
        public UserRepository(HomeInsideOutContext context) : base(context) { } 
    }
}
