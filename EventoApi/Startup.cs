using System.Text;
using EventoCore.Domain;
using EventoCore.Extensions;
using EventoCore.Repositories;
using EventoInfrastructure.Mappers;
using EventoInfrastructure.Repositories;
using EventoInfrastructure.Services.Events;
using EventoInfrastructure.Services.Initializers;
using EventoInfrastructure.Services.Jwt;
using EventoInfrastructure.Services.Tickets;
using EventoInfrastructure.Services.Users;
using EventoInfrastructure.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using static EventoApi.Constants.Constants;

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
            _securityKey = Configuration.GetValue<string>("JWT:SecurityKey");
            _applicationUrl = Configuration.GetValue<string>("JWT:ApplicationUrl");
            _expiryTimeInMinutes = Configuration.GetValue<int>("JWT:ExpiryTimeInMinutes");
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            SetupScopedServices(services);
            SetupSingletonServices(services);
            SetupAuthentication(services);
            SetupOthers(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }

            SetupApplicationBuilder(app);
            SeedData(app);
        }

        private void SetupScopedServices(IServiceCollection services) {
            services.AddScoped<IEventRepository, InMemoryEventRepository>();
            services.AddScoped<IUserRepository, InMemoryUserRepository>();
            services.AddScoped<IEventService, EventService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITicketService, TicketService>();
            services.AddScoped<IDataInitializer, DataInitializer>();
        }

        private void SetupSingletonServices(IServiceCollection services) {
            services.Configure<AppSettings>(Configuration.GetSection("App"));
            services.AddSingleton(AutoMapperConfig.Initialize());
            services.AddSingleton<IJwtService, JwtService>();
            services.AddSingleton(new JwtSettings(_securityKey, _applicationUrl, _expiryTimeInMinutes));

            // This is another approach when you cast automatically sub-object from appsettings.json
            // services.Configure<JwtSettings>(Configuration.GetSection("JWT"));
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

        private void SetupOthers(IServiceCollection services) {
            services.AddControllers();
            services.AddAuthorization((option) => {
                option.AddPolicy(
                    POLICY_HAS_ADMIN_ROLE,
                    (policy) => policy.RequireRole(UserRole.Admin.FromEnumToString())
                );
            });
            services.AddMemoryCache();
        }

        private void SetupApplicationBuilder(IApplicationBuilder app) {
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }

        private void SeedData(IApplicationBuilder app) {
            IOptions<AppSettings> appSettings = app.ApplicationServices
                .GetService<IOptions<AppSettings>>();
            if (appSettings.Value.SeedData) {
                app.ApplicationServices
                    .GetService<IDataInitializer>()
                    .SeedDataAsync();
            }
        }

    }

}
