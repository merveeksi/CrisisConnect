using Core.Persistence.Repositories;

namespace Core.Security.Entities;

public class RefreshToken :Entity<long>
{
    public long UserId { get; set; }
    public string Token { get; set; }
    public DateTime Expires { get; set; }
    public string CreatedByIp { get; set; }
    public DateTime? Revoked { get; set; }   //iptal edildi
    public string? RevokedByIp { get; set; }
    public string? ReplacedByToken { get; set; }
    public string? ReasonRevoked { get; set; }

    public virtual User User { get; set; } = null!;
    public bool IsExpired { get; set; } 
    public bool IsRevoked { get; set; }

    public RefreshToken()
    {
        Token = string.Empty;
        CreatedByIp = string.Empty;
    }

    public RefreshToken(long userId, string token, DateTime expires, string createdByIp)
    {
        UserId = userId;
        Token = token;
        Expires = expires;
        CreatedByIp = createdByIp;
    }

    public RefreshToken(long id, long userId, string token, DateTime expires, string createdByIp)
        : base(id)
    {
        UserId = userId;
        Token = token;
        Expires = expires;
        CreatedByIp = createdByIp;
    }
}