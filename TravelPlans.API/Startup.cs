using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TravelPlans.API.Common.Filters;
using TravelPlans.Application;
using TravelPlans.Infrastructure;

namespace TravelPlans.API
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
            services.AddControllers(options =>
            {
                options.Filters.Add(new ApiExceptionFilterAttribute());
            });
            services.AddOptions();
            services.AddDatabase(Configuration);
            services.AddApplication();
            services.AddSwaggerDocs();
            services.AddCorsPolicy();
            services.AddAuthenticationAndAuthorization(Configuration);
            services.AddMassTransit();
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

            app.UseCorsPolicy();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
                
            app.UseSwaggerDocs();
        }
    }
}
