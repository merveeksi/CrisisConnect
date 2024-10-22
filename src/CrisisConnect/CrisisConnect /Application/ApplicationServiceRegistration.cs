using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

//Application katmanındaki tüm servisleri eklemek için kullanılır
public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly()); //AutoMapper'ı projeye dahil etmek için kullanılır
        
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        });
        return services;
    }
}