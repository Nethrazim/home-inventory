using AutoMapper;
using HomeInsideOut.Common.DataLayer.Repositories;
using HomeInsideOut.Common.Utils.Helpers;
using HomeInsideOut.DataLayer.Data;
using HomeInsideOut.DataLayer.Models;
using Microsoft.EntityFrameworkCore;
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
