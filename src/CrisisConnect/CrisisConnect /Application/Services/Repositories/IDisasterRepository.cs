using Core.Persistence.Repositories;
using Domain.Entities;

namespace Application.Services.Repositories;

public interface IDisasterRepository:IAsyncRepository<Disaster, Guid>, IRepository<Disaster, Guid>
{
}