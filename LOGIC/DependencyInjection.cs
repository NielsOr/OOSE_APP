using LOGIC.Interfaces.Services;
using LOGIC.Services;
using Microsoft.Extensions.DependencyInjection;

namespace LOGIC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddLogic(this IServiceCollection services)
        {
            services.AddScoped<ILeeruitkomstService, LeeruitkomstService>();
            services.AddScoped<ITentamineringService, TentamineringService>();
            services.AddScoped<IRubricService, RubricService>();
            services.AddScoped<IEvlService, EvlService>();
            return services;
        }
    }
}