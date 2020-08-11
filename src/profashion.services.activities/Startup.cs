using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using profashion.business.Models;
using profashion.business.Repositories;
using profashion.core.Commands;
using profashion.core.Mongo;
using profashion.core.RabbitMQ;
using profashion.services.activities.Handlers;
using profashion.services.activities.Services;
using profashion.services.activities.Services.DatabaseSeeder;

namespace profashion.services.activities
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen();
            services.AddApiVersioning(o =>
            {
                o.ReportApiVersions = true;
                o.AssumeDefaultVersionWhenUnspecified = true;
                o.DefaultApiVersion = new ApiVersion(1, 0);
                o.ApiVersionReader = new HeaderApiVersionReader("x-api-version");
            });
            services.AddRabbitMq(Configuration);
            services.AddMongo(Configuration);
            services.AddScoped<ICommandHandler<CreateActivityCommand>, CreateActivityCommandHandler>();
            services.AddScoped<IRepository<Activity>, ActivityRepository>();
            services.AddScoped<IRepository<Category>, CategoryRepository>();
            services.AddScoped<IDatabaseSeeder, ActivitySeederService>();
            services.AddScoped<IDatabaseSeeder, CategorySeederService>();
            services.AddScoped<IService<Activity>, ActivityService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", $"{typeof(Startup).Namespace} API v1");
            });

            app.UseAuthorization();

            app.ApplicationServices.GetService<IDatabaseInitializer>().InitializeAsync();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}