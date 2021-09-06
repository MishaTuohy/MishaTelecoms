using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MishaTelecoms.API.Services;
using MishaTelecoms.Application.Interfaces.Services;
using MishaTelecoms.Domain.Settings;
using MishaTelecoms.Infrastructure;

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

            // Assign your config so you can reuse it in Data layer
            var dbConnectionConfig = new DbConnectionConfig();
            Configuration.GetSection("DbConnectionConfig").Bind(dbConnectionConfig);
            services.AddSingleton(dbConnectionConfig);

            // Hook up infrastructure dependancies
            services.AddInfrastructure(Configuration);
            services.AddSwaggerGen(options => 
            {
                options.SwaggerDoc("v1",
                    new Microsoft.OpenApi.Models.OpenApiInfo
                    {
                        Title = "Swagger Demo API",
                        Description = "Demo API for showing Swagger",
                        Version = "v1"
                    });
            });
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Middleware
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(options => 
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger Demo API");
            });
        }
    }
}
