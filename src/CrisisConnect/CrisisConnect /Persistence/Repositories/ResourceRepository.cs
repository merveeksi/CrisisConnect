using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ResourceRepository:EfRepositoryBase<Resource, Guid, BaseDbContext>, IResourceRepository
{
    public ResourceRepository(BaseDbContext context) : base(context)
    {
    }
}