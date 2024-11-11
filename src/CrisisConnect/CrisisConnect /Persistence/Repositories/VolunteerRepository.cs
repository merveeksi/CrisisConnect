using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Domain.ValueObjects;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class VolunteerRepository : EfRepositoryBase<Volunteer, VolunteerId, BaseDbContext>, IVolunteerRepository
{
    public VolunteerRepository(BaseDbContext context) : base(context)
    {
    }
}