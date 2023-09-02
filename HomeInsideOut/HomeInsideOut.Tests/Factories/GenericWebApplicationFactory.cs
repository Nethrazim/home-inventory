using HomeInsideOut.Tests.Utilities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace HomeInsideOut.Tests.Factories
{
    public class GenericWebApplicationFactory<TStartup, TContext, TSeed>
        : WebApplicationFactory<TStartup>
        where TStartup : class
        where TContext : DbContext
        where TSeed : class, ISeedDataClass<TContext>
    {

        private static string databaseName = $"HomeInsideOut.Tests.{Guid.NewGuid().ToString()}";
        private static string connectionString = $"Server=DESKTOP-6M09VOS\\SQLEXPRESS;Database={databaseName};Trusted_Connection=True;MultipleActiveResultSets=true";

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            base.ConfigureWebHost(builder);
            builder.UseEnvironment("Development");
            builder.ConfigureServices(services =>
            {
                var dbContextDescriptor = services.SingleOrDefault(d => d.ServiceType ==
                                            typeof(DbContextOptions<TContext>));

                services.Remove(dbContextDescriptor);

                services.AddSingleton<ISeedDataClass<TContext>, TSeed>();

                services.AddDbContext<TContext>((sp, options) =>
                {
                    options.UseSqlServer(connectionString);
                    options.EnableSensitiveDataLogging();
                });

                var sp = services.BuildServiceProvider();
                using (var scope = sp.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;
                    var db = scopedServices.GetRequiredService<TContext>();
                    var logger = scopedServices.GetRequiredService<ILogger<GenericWebApplicationFactory<TStartup, TContext, TSeed>>>();

                    var seeder = scopedServices.GetRequiredService<ISeedDataClass<TContext>>();



                    try
                    {
                        db.Database.EnsureDeleted();
                        db.Database.EnsureCreated();
                        seeder.Seed(db);
                    }
                    catch (Exception ex)
                    {
                        logger.LogError(ex, $"An error occurred seeding the database with test messages. Error: {ex.Message}");
                    }
                }
            });
        }
    }
}
