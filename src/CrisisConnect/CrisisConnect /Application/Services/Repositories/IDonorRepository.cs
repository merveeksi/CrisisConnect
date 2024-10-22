using Core.Persistence.Repositories;
using Domain.Entities;

namespace Application.Services.Repositories;

public interface IDonorRepository:IAsyncRepository<Donor, Guid>, IRepository<Donor, Guid>
{
    
}
