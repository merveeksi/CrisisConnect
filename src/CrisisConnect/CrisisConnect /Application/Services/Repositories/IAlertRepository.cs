using Core.Persistence.Repositories;
using Domain.Entities;
using Domain.ValueObjects;

namespace Application.Services.Repositories;

public interface IAlertRepository:IAsyncRepository<Alert, AlertId>, IRepository<Alert, AlertId>
{
    
}