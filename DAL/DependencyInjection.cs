﻿using DAL.Context;
using DAL.Repositories;
using LOGIC.Interfaces;
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

            return services;
        }
    }
}