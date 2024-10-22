using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class TeamRepository: EfRepositoryBase<Team, Guid, BaseDbContext>, ITeamRepository
{
    public TeamRepository(BaseDbContext context) : base(context)
    {
    }
}