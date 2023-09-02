using Microsoft.Extensions.DependencyInjection;
using Module.Identity.DataLayer.Data;
using Module.Identity.DataLayer.Repositories;

namespace Module.Identity.BusinessLayer
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddIdentityRepositories(this IServiceCollection services)
        {
            services.AddDbContext<IdentityDbContext>();
            services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }
    }
}
