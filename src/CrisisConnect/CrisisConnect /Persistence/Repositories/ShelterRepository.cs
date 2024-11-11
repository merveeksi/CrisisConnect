using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Domain.ValueObjects;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ShelterRepository: EfRepositoryBase<Shelter, ShelterId, BaseDbContext>, IShelterRepository
{
    public ShelterRepository(BaseDbContext context) : base(context)
    {
    }
}