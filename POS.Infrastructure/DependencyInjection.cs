
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using POS.Application.Interfaces.Repositories;
using POS.Application.Interfaces.Services;
using POS.Infrastructure.Repositories;
using POS.Infrastructure.Services;
using POS.Infrastructure.Services.Authentication;
using JwtSettings = POS.Infrastructure.Services.Authentication.JwtSettings;



namespace Infrastructure
{
    public static class DependencyInjection
    {
        private const string JwtSettingsSectionName = "JwtSettings";
        public static IServiceCollection AddInfrastructureServices(
            this IServiceCollection services,
            IConfiguration configuration
            )
        {

            services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));


            // Register JwtTokenGenerator
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IItemRepository, ItemRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IPasswordHasher, PasswordHasher>();

            return services;
        }

    }
}
