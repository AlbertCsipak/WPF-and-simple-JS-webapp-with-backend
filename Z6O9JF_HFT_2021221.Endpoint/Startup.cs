using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Z6O9JF_HFT_2021221.Data;
using Z6O9JF_HFT_2021221.Endpoint.Services;
using Z6O9JF_HFT_2021221.Logic;
using Z6O9JF_HFT_2021221.Repository;

namespace Z6O9JF_HFT_2021221.Endpoint
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddTransient<ICarLogic, CarLogic>();
            services.AddTransient<IMechanicLogic, MechanicLogic>();
            services.AddTransient<IOwnerLogic, OwnerLogic>();
            services.AddTransient<IBrandLogic, BrandLogic>();
            services.AddTransient<IAdvancedLogic, AdvancedLogic>();
            services.AddTransient<IEngineLogic, EngineLogic>();
            services.AddTransient<ICarServiceLogic, CarServiceLogic>();

            services.AddTransient<ICarRepository, CarRepository>();
            services.AddTransient<IMechanicRepository, MechanicRepository>();
            services.AddTransient<IOwnerRepository, OwnerRepository>();
            services.AddTransient<IBrandRepository, BrandRepository>();
            services.AddTransient<IEngineRepository, EngineRepository>();
            services.AddTransient<ICarServiceRepository, CarServiceRepository>();

            services.AddSignalR();

            services.AddTransient<MyDbContext, MyDbContext>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseExceptionHandler(c => c.Run(async context =>
            {
                var exception = context.Features
                .Get<IExceptionHandlerPathFeature>()
                .Error;
                var response = new { error = exception.Message };
                await context.Response.WriteAsJsonAsync(response);
            }));

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<SignalRHub>("/hub");
            });
        }
    }
}
