using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using Core.Security.Encryption;
using Core.Security.Entities;
using Core.Security.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Core.Security.JWT;

public class JwtHelper : ITokenHelper
{
    public IConfiguration Configuration { get; }
    private readonly TokenOptions _tokenOptions;
    private DateTime _accessTokenExpiration;


    public JwtHelper(IConfiguration configuration)
    {
        Configuration = configuration;
        const string configurationSection = "TokenOptions";
        _tokenOptions =
            Configuration.GetSection(configurationSection).Get<TokenOptions>()
            ?? throw new NullReferenceException($"\"{configurationSection}\" section cannot found in configuration.");
    }

    public RefreshToken CreateRefreshToken(User user, string ipAddress)
    {
        RefreshToken refreshToken = 
            new() 
            {
                UserId = user.Id,
                Token = RandomRefreshToken(),
                Expires = DateTime.UtcNow.AddDays(7),
                CreatedByIp = ipAddress
            };
        return refreshToken;
    }

    public AccessToken CreateToken(User user, IList<OperationClaim> operationClaims)
    {
        _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
        SecurityKey securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
        SigningCredentials signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);
        JwtSecurityToken jwt = CreateJwtSecurityToken(_tokenOptions, user, signingCredentials, operationClaims);
        JwtSecurityTokenHandler jwtSecurityTokenHandler = new();
        string? token = jwtSecurityTokenHandler.WriteToken(jwt);

        return new AccessToken { Token = token, Expiration = _accessTokenExpiration };
    }
    
    public TokenResponse RefreshToken(string accessToken, string refreshToken, string ipAddress, User user)
    {
        var savedRefreshToken = user.RefreshTokens.SingleOrDefault(rt => rt.Token == refreshToken);

        if (savedRefreshToken == null || savedRefreshToken.IsExpired || savedRefreshToken.IsRevoked)
            throw new SecurityTokenException("Invalid or expired refresh token.");

        var newAccessToken = CreateToken(user, user.OperationClaims);
        var newRefreshToken = CreateRefreshToken(user, ipAddress);

        savedRefreshToken.Revoked = DateTime.UtcNow;
        savedRefreshToken.RevokedByIp = ipAddress;
        savedRefreshToken.ReplacedByToken = newRefreshToken.Token;

        user.RefreshTokens.Add(newRefreshToken);

        return new TokenResponse
        {
            AccessToken = newAccessToken.Token,
            RefreshToken = newRefreshToken.Token
        };
    }

    public JwtSecurityToken CreateJwtSecurityToken(
        TokenOptions tokenOptions,
        User user,
        SigningCredentials signingCredentials,
        IList<OperationClaim> operationClaims
    )
    {
        JwtSecurityToken jwt =
            new(
                tokenOptions.Issuer,
                tokenOptions.Audience,
                expires: _accessTokenExpiration,
                notBefore: DateTime.Now,
                claims: SetClaims(user, operationClaims),
                signingCredentials: signingCredentials
            );
        return jwt;
    }

    private IEnumerable<Claim> SetClaims(User user, IList<OperationClaim> operationClaims)
    {
        List<Claim> claims = new();
        claims.AddNameIdentifier(user.Id.ToString());
        claims.AddEmail(user.Email);
        claims.AddName($"{user.FirstName} {user.LastName}");
        claims.AddRoles(operationClaims.Select(c => c.Name).ToArray());
        return claims;
    }

    private string RandomRefreshToken()
    {
        byte[] numberByte = new byte[32];
        using var random = RandomNumberGenerator.Create();
        random.GetBytes(numberByte);
        return Convert.ToBase64String(numberByte);
    }
}

public class TokenResponse
{
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
}