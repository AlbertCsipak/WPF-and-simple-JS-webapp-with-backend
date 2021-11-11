using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Z6O9JF_HFT_2021221.Data;
using Z6O9JF_HFT_2021221.Logic;
using Z6O9JF_HFT_2021221.Models;
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

            services.AddTransient<MyDbContext, MyDbContext>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
