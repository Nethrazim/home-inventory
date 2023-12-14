using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Module.Identity.BusinessLayer;
using Module.Identity.DataLayer;

namespace Module.Identity.ServiceExtensions
{
    public static class ModuleExtensions
    {
        public static IServiceCollection AddIdentityModule(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddIdentityInjectionReferences()
                .AddIdentityServices();
            return services;
        }
    }
}
