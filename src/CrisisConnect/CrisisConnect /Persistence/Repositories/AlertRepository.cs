using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class AlertRepository:EfRepositoryBase<Alert, Guid, BaseDbContext>, IAlertRepository
{
    public AlertRepository(BaseDbContext context) : base(context)
    {
    }
}