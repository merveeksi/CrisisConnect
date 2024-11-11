using Core.Persistence.Repositories;
using Domain.Entities;
using Domain.ValueObjects;

namespace Application.Services.Repositories;

public interface IVolunteerRepository:IAsyncRepository<Volunteer, VolunteerId>, IRepository<Volunteer, VolunteerId>
{
}
