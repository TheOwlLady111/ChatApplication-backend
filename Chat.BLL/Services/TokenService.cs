using Chat.BLL.Contracts;
using Chat.BLL.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Chat.BLL.Services;

public class TokenService : ITokenService
{
    private readonly AuthSettings _authSettings;

    public TokenService(IOptions<AuthSettings> options)
    {
        _authSettings = options.Value ?? throw new Exception("AuthSettings is null"); ;
    }

    public string GenerateToken(int userId)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_authSettings.SecurityKey));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
        };

        var jwt = new JwtSecurityToken(
            _authSettings.Issuer,
            _authSettings.Audience,
            claims: claims,
            DateTime.UtcNow,
            expires: DateTime.UtcNow.AddMinutes(_authSettings.TokenLifetime),
            signingCredentials: credentials);

        var token = new JwtSecurityTokenHandler().WriteToken(jwt);

        return token;
    }
}