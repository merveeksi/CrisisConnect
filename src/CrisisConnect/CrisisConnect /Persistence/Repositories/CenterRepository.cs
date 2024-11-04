using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class CenterRepository:EfRepositoryBase<Center, Guid, BaseDbContext>, ICenterRepository
{
    public CenterRepository(BaseDbContext context) : base(context)
    {
    }

    public Task<List<Center>> GetAllAsync()
    {
        throw new NotImplementedException();
    }
}