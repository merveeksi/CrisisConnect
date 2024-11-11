using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Domain.ValueObjects;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class DisasterRepository:EfRepositoryBase<Disaster, DisasterId, BaseDbContext>, IDisasterRepository
{
    public DisasterRepository(BaseDbContext context) : base(context)
    {
    }
}