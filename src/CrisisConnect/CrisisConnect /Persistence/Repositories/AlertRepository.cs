using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Domain.ValueObjects;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class AlertRepository:EfRepositoryBase<Alert, AlertId, BaseDbContext>, IAlertRepository
{
    public AlertRepository(BaseDbContext context) : base(context)
    {
    }
}