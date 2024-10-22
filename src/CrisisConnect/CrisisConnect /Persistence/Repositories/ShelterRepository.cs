using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ShelterRepository: EfRepositoryBase<Shelter, Guid, BaseDbContext>, IShelterRepository
{
    public ShelterRepository(BaseDbContext context) : base(context)
    {
    }
}