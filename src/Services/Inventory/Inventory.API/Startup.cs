using AutoMapper;
using Inventory.API.Profiles;
using Inventory.API.Services;
using Inventory.Core.Interfaces;
using Inventory.Core.Interfaces.Services;
using Inventory.Core.Services;
using Inventory.Infrastructure.Data;
using Inventory.Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Reflection;

namespace Inventory.API
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration) => _configuration = configuration;

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddGrpc().Services
                .AddGrpcReflection()
                .AddCustomDbContext(_configuration)
                .AddCustomAutoMapper();

            services.AddScoped<IStuffTypeService, StuffTypeService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGrpcService<InventoryService>();

                if (env.IsDevelopment())
                {
                    endpoints.MapGrpcReflectionService();
                }
            });
        }
    }

    public static class ServicesConfigurationExtensions
    {
        public static IServiceCollection AddCustomDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddEntityFrameworkSqlServer().AddDbContext<InventoryContext>(options =>
            {
                options.UseSqlServer(configuration["ConnectionString"], sqlServerOptions =>
                {
                    sqlServerOptions.MigrationsAssembly(typeof(Startup).GetTypeInfo().Assembly.GetName().Name);
                    sqlServerOptions.EnableRetryOnFailure(5, TimeSpan.FromSeconds(30), null);
                });
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            }, ServiceLifetime.Scoped);

            return services;
        }

        public static IServiceCollection AddCustomAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new StuffTypeProfile());
            });
            services.AddSingleton(mappingConfig.CreateMapper());

            return services;
        }
    }
}
