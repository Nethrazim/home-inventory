using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Module.Identity.BusinessLayer.Profiles;
using Module.Identity.BusinessLayer.Services;
using Module.Identity.DataLayer.Data;
using Shared.BusinessLayer.Config;
using Shared.DataLayer.Data;
using FluentAssertions;
using Microsoft.Extensions.Configuration;
using System.Data.Entity.Infrastructure;
using HomeInsideOut.Tests.Factories;
using Microsoft.AspNetCore.Hosting.Server;
using HomeInsideOut.Tests.Utilities;
using HomeInsideOut.Api;

namespace HomeInsideOut.Tests.Tests.UnitTests.Services
{
    [Collection("API collection")]
    public class UserServiceTests
    {
        private HttpClient Client;
        public UserServiceTests(GenericWebApplicationFactory<Program, HomeInsideOutContext, SeedData> factory)
        {
            Client = factory.CreateClient();
        }

        [Fact]
        public async Task TestGenerateTokenAsync()
        {

          
            var jwtConfig = Options.Create<JwtConfig>(new JwtConfig() { SigningKey = "test1signingkey"});
            var mockMapper = new MapperConfiguration(cfg => {
                cfg.AddProfiles(new List<Profile>() { new InventoryProfile(), new UserProfile() });
            }).CreateMapper();

            var value = new KeyValuePair<string, string>(
                "ConnectionStrings:DbConnectionString",
                "Server=DESKTOP-CCILHCT\\MSSQLSERVER01;Database=HomeInsideOut.Tests;Trusted_Connection=True;MultipleActiveResultSets=true"
            );
            var configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(new[] { value })
                .Build();

            var dbOptions = new DbContextOptionsBuilder<IdentityDbContext>().Options;

            var userService = new UserService(jwtConfig, mockMapper, new IdentityDbContext(configuration, dbOptions));
            (await userService.GenerateTokenAsync("test1@gmail.com", "test1password")).Should().NotBeNull();
            
        }
        
    }
}
