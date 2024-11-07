using Microsoft.Extensions.DependencyInjection;

namespace Core.Security;

public static class SecurityServiceRegistration
{
    public static IServiceCollection AddSecurityServices(this IServiceCollection services)
    {
        // services.AddScoped<ITokenHelper, JwtHelper>();
        // //services.AddScoped<IEmailAuthenticatorHelper, EmailAuthenticatorHelper>();
        // services.AddScoped<IOtpAuthenticatorHelper, OtpNetOtpAuthenticatorHelper>();
        return services;
    }
}