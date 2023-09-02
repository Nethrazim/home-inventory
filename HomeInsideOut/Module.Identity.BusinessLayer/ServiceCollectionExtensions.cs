using Microsoft.Extensions.DependencyInjection;
using Module.Identity.BusinessLayer.Services;

namespace Module.Identity.BusinessLayer
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            return services;
        }
    }
}
