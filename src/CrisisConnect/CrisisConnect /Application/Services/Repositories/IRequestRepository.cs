using Core.Persistence.Repositories;
using Domain.Entities;

namespace Application.Services.Repositories;

public interface IRequestRepository:IAsyncRepository<Request, Guid>, IRepository<Request, Guid>
{
    
}
