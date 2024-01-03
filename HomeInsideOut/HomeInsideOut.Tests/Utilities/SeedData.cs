using Shared.DataLayer.Data;
using Shared.DataLayer.Models;

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
                HashedPassword = "test1password",
                Salt = "asd"
            };

            dbContext.Users.Attach(newUser);
            dbContext.SaveChanges();
        }
    }
}
