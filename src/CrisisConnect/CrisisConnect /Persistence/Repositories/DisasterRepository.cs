using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class DisasterRepository:EfRepositoryBase<Disaster, Guid, BaseDbContext>, IDisasterRepository
{
    public DisasterRepository(BaseDbContext context) : base(context)
    {
    }
}