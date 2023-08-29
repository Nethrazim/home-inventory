using HomeInsideOut.DataLayer.Data;
using HomeInsideOut.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeInsideOut.Tests.Utilities
{
    public class SeedData : ISeedDataClass<HomeInsideOutContext>
    {
        public void Seed(HomeInsideOutContext dbContext)
        {
            User newUser = new User()
            {
                Username = "User1",
                Email = "test1@gmail.com",
                HashedPassword = "asd",
                Salt = "asd"
            };

            dbContext.Users.Attach(newUser);
            dbContext.SaveChanges();
        }
    }
}
