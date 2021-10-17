using LOGIC.Interfaces;
using LOGIC.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DAL
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddLogic(this IServiceCollection services)
        {
            services.AddScoped<ILeeruitkomstService, LeeruitkomstService>();
            services.AddScoped<IEvlService, EvlService>();
            return services;
        }
    }
}