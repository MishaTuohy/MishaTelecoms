using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MishaTelecoms.API.Services;
using MishaTelecoms.Application.Interfaces.Repositories;
using MishaTelecoms.Application.Interfaces.Services;
using MishaTelecoms.Domain.Settings;
using MishaTelecoms.Infrastructure;
using MishaTelecoms.Infrastructure.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MishaTelecoms.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddScoped<ICDRService, CDRService>();

            services.AddAutoMapper(typeof(Startup));

            //assign your config so you can reuse it in Data layer
            var dbConnectionConfig = new DbConnectionConfig();
            Configuration.GetSection("ConnectionConfig").Bind(dbConnectionConfig);
            services.AddSingleton(dbConnectionConfig);

            //hook up infrastructure dependancies
            services.AddInfrastructure(Configuration);

        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }



            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
