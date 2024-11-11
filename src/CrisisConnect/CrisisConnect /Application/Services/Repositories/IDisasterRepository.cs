using Core.Persistence.Repositories;
using Domain.Entities;
using Domain.ValueObjects;

namespace Application.Services.Repositories;

public interface IDisasterRepository:IAsyncRepository<Disaster, DisasterId>, IRepository<Disaster, DisasterId>
{
}