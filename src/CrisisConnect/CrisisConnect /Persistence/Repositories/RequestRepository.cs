using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class RequestRepository: EfRepositoryBase<Request, Guid, BaseDbContext>, IRequestRepository
{
    public RequestRepository(BaseDbContext context) : base(context)
    {
    }
}