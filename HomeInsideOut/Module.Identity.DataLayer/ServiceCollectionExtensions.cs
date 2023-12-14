using Microsoft.Extensions.DependencyInjection;
using Module.Identity.DataLayer.Data;

namespace Module.Identity.DataLayer
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddIdentityInjectionReferences(this IServiceCollection services)
        {
            services.AddDbContext<IdentityDbContext>();
            return services;
        }
    }
}
