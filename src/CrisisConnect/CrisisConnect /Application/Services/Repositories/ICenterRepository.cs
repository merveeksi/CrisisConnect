using Core.Persistence.Repositories;
using Domain.Entities;

namespace Application.Services.Repositories;

public interface ICenterRepository:IAsyncRepository<Center, Guid>, IRepository<Center, Guid>
{
    
}
