using Core.Persistence.Repositories;
using Domain.Entities;

namespace Application.Services.Repositories;

public interface IVolunteerRepository:IAsyncRepository<Volunteer, Guid>, IRepository<Volunteer, Guid>
{
}
