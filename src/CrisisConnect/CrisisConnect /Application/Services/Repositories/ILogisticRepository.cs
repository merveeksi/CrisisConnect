using Core.Persistence.Repositories;
using Domain.Entities;

namespace Application.Services.Repositories;

public interface ILogisticRepository:IAsyncRepository<Logistic, Guid>, IRepository<Logistic, Guid>
{
    
}
