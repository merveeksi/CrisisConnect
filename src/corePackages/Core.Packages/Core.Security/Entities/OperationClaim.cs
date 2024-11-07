using Core.Persistence.Repositories;

namespace Core.Security.Entities;

public class OperationClaim :Entity<long>
{
    public string Name { get; set; }

    public virtual ICollection<UserOperationClaim> UserOperationClaims { get; set; } = null!;

    public OperationClaim()
    {
        Name = string.Empty;
    }

    public OperationClaim(string name)
    {
        Name = name;
    }

    public OperationClaim(long id, string name)
        : base(id)
    {
        Name = name;
    }

}
