using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace Application.Services.Repositories;

public interface IUserOperationClaimRepository : IAsyncRepository<UserOperationClaim, long>, IRepository<UserOperationClaim, long>
{
    Task<IList<OperationClaim>> GetOperationClaimsByUserIdAsync(int userId);
}