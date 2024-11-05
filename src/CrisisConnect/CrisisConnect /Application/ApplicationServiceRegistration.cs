using System.Reflection;
using Core.Application.Rules;
using FluentValidation;
using Core.Application.Pipelines.Validation;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

//Application katmanındaki tüm servisleri eklemek için kullanılır
public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly()); //AutoMapper'ı projeye dahil etmek için kullanılır
       
        services.AddSubClassesOfType(Assembly.GetExecutingAssembly(),typeof(BaseBusinessRules));

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            configuration.AddOpenBehavior(typeof(RequestValidationBehavior<,>));
            // configuration.AddOpenBehavior(typeof(TransactionScopeBehavior<,>));
            // configuration.AddOpenBehavior(typeof(CachingBehavior<,>));
            // configuration.AddOpenBehavior(typeof(CacheRemovingBehavior<,>));
            // configuration.AddOpenBehavior(typeof(LoggingBehavior<,>));
        });
        
        // services.AddSingleton<LoggerServiceBase, MsSqlLogger>();
        //
        return services;
    }
    
    public static IServiceCollection AddSubClassesOfType(
        this IServiceCollection services,
        Assembly assembly,
        Type type,
        Func<IServiceCollection, Type, IServiceCollection>? addWithLifeCycle = null
    )
    {
        var types = assembly.GetTypes().Where(t => t.IsSubclassOf(type) && type != t).ToList();
        foreach (var item in types)
            if (addWithLifeCycle == null)
                services.AddScoped(item);

            else
                addWithLifeCycle(services, type);
        return services;
    }
    
}