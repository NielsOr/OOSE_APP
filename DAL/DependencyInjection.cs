using DAL.Context;
using DAL.Files;
using DAL.Repositories;
using LOGIC.Interfaces.Files;
using LOGIC.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DAL
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)));

            services.AddScoped<IEvlRepository, EvlRepository>();
            services.AddScoped<ITentamineringRepository, TentamineringRepository>();
            services.AddScoped<ILeeruitkomstRepository, LeeruitkomstRepository>();
            services.AddScoped<IRubricRepository, RubricRepository>();
            services.AddScoped<IRubricsFileBuilder, RubricsFileBuilder>();

            return services;
        }
    }
}