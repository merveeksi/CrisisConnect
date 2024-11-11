using Core.Persistence.Repositories;
using Domain.Entities;
using Domain.ValueObjects;

namespace Application.Services.Repositories;

public interface IShelterRepository:IAsyncRepository<Shelter, ShelterId>, IRepository<Shelter, ShelterId>
{
    
}
