using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class DonorRepository:EfRepositoryBase<Donor, Guid, BaseDbContext>, IDonorRepository
{
    public DonorRepository(BaseDbContext context) : base(context)
    {
    }
}