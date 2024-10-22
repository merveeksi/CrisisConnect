using Core.Persistence.Repositories;
using Domain.Entities;

namespace Application.Services.Repositories;

public interface IResourceRepository:IAsyncRepository<Resource, Guid>, IRepository<Resource, Guid>
{
    
}
