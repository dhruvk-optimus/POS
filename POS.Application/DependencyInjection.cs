using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using POS.Application.Interfaces.Services;
using POS.Application.Features.Order.Services;

namespace POS.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddScoped<IOrderCreationService, OrderCreationService>();  

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
