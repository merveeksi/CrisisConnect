using Application.Services.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;
using Persistence.Repositories;

namespace Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<BaseDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("CrisisConnect")));

        services.AddScoped<IAlertRepository, AlertRepository>();
        services.AddScoped<ICenterRepository, CenterRepository>();
        services.AddScoped<IDisasterRepository, DisasterRepository>();
        services.AddScoped<IDonorRepository, DonorRepository>();
        services.AddScoped<ILogisticRepository, LogisticRepository>();
        services.AddScoped<IRequestRepository, RequestRepository>();
        services.AddScoped<IResourceRepository, ResourceRepository>();
        services.AddScoped<IShelterRepository, ShelterRepository>();
        services.AddScoped<ITeamRepository, TeamRepository>();
        services.AddScoped<IVolunteerRepository, VolunteerRepository>();


        
        return services;
    }
}
