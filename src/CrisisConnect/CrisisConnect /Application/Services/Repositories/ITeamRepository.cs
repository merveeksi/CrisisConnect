using Core.Persistence.Repositories;
using Domain.Entities;

namespace Application.Services.Repositories;

public interface ITeamRepository:IAsyncRepository<Team, Guid>, IRepository<Team, Guid>
{
    
}
