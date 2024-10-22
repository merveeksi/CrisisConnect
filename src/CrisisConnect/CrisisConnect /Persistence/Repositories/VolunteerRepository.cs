using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class VolunteerRepository : EfRepositoryBase<Volunteer, Guid, BaseDbContext>, IVolunteerRepository
{
    public VolunteerRepository(BaseDbContext context) : base(context)
    {
    }
}