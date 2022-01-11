using LOGIC.Interfaces.Services;
using LOGIC.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DAL
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddLogic(this IServiceCollection services)
        {
            services.AddScoped<IEvlService, EvlService>();
            services.AddScoped<ILeeruitkomstService, LeeruitkomstService>();
            services.AddScoped<ITentamineringService, TentamineringService>();
            services.AddScoped<IRubricService, RubricService>();
            return services;
        }
    }
}