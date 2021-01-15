using System.Text;
using EventoCore.Repositories;
using EventoInfrastructure.Mappers;
using EventoInfrastructure.Repositories;
using EventoInfrastructure.Services.Events;
using EventoInfrastructure.Services.Users;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;

namespace EventoApi {

    public class Startup {

        /*------------------------ FIELDS REGION ------------------------*/
        private readonly string _applicationUrl;
        private readonly string _securityKey;
        private readonly int _expiryTimeInMinutes;

        public IConfiguration Configuration { get; }

        /*------------------------ METHODS REGION ------------------------*/
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
            _applicationUrl = Configuration.GetValue<string>("Urls");
            _securityKey = Configuration.GetValue<string>("JWT:SecurityKey");
            _expiryTimeInMinutes = Configuration.GetValue<int>("JWT:ExpiryTimeInMinutes");
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            services.AddControllers();
            SetupScopedServices(services);
            SetupSingletonServices(services);
            SetupAuthentication(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }

        private void SetupScopedServices(IServiceCollection services) {
            services.AddScoped<IEventRepository, InMemoryEventRepository>();
            services.AddScoped<IUserRepository, InMemoryUserRepository>();
            services.AddScoped<IEventService, EventService>();
            services.AddScoped<IUserService, UserService>();
        }

        private void SetupSingletonServices(IServiceCollection services) {
            services.AddSingleton(AutoMapperConfig.Initialize());
        }

        private void SetupAuthentication(IServiceCollection services) {
            services.AddAuthentication(option => {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer((option) => {
                option.TokenValidationParameters = new TokenValidationParameters {
                    ValidateAudience = false,
                    ValidIssuer = _applicationUrl,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_securityKey))
                };
            });
        }

    }

}
