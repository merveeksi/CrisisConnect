using Core.Persistence.Repositories;
using Domain.Entities;

namespace Application.Services.Repositories;

public interface IAlertRepository:IAsyncRepository<Alert, Guid>, IRepository<Alert, Guid>
{
    
}