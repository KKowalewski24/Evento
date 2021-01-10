using EventoCore.Repositories;
using EventoInfrastructure.Mappers;
using EventoInfrastructure.Repositories;
using EventoInfrastructure.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EventoApi {

    public class Startup {

        /*------------------------ FIELDS REGION ------------------------*/
        public IConfiguration Configuration { get; }

        /*------------------------ METHODS REGION ------------------------*/
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            SetupScopedServices(services);
            SetupSingletonServices(services);

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }

        private void SetupScopedServices(IServiceCollection services) {
            services.AddScoped<IEventRepository, InMemoryEventRepository>();
            services.AddScoped<IUserRepository, InMemoryUserRepository>();
            services.AddScoped<IEventService, EventService>();
        }

        private static void SetupSingletonServices(IServiceCollection services) {
            services.AddSingleton(AutoMapperConfig.Initialize());
        }

    }

}
