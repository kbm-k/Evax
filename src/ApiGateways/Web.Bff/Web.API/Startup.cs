using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using GrpcInventory;
using Web.API.Profiles.Inventory;
using Web.API.Services.Inventory;
using Web.API.Services.Inventory.Interfaces;

namespace Web.API
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddGrpcClient<Inventory.InventoryClient>(options =>
            {
                options.Address = new Uri("https://localhost:5001");
            });

            services
                .AddCustomAutoMapper()
                .AddInventoryServices();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("CorsPolicy");
            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                endpoints.MapControllers();
            });
        }
    }

    public static class ServicesConfigurationExtensions
    {
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

        public static IServiceCollection AddInventoryServices(this IServiceCollection services)
        {
            services.AddSingleton<IStuffTypeService, StuffTypeService>();

            return services;
        }
    }
}
