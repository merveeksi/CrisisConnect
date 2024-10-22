using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class LogisticRepository: EfRepositoryBase<Logistic, Guid, BaseDbContext>, ILogisticRepository
{
    public LogisticRepository(BaseDbContext context) : base(context)
    {
    }
}