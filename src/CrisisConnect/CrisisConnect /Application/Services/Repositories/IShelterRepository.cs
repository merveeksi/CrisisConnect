using Core.Persistence.Repositories;
using Domain.Entities;

namespace Application.Services.Repositories;

public interface IShelterRepository:IAsyncRepository<Shelter, Guid>, IRepository<Shelter, Guid>
{
    
}
