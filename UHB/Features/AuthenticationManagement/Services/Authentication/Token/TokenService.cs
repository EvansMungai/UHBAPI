using UHB.Domain.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace UHB.Features.AuthenticationManagement.Services.Authentication.Token;

public class TokenService : ITokenService
{
    private readonly IConfiguration _config;
    private readonly SymmetricSecurityKey _key;
    private readonly SigningCredentials _creds;
    private readonly string? jwtKey;
    private readonly string? jwtIssuer;
    private readonly string? webAudience;
    private readonly string? posAudience;
    private readonly string? mobileAudience;
    public TokenService(IConfiguration config)
    {
        _config = config;

        jwtKey = config["JWT:Key"];
        _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
        _creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256);

        jwtIssuer = _config["JWT:Issuer"];
        webAudience = _config["JWT:AUDIENCES:WEB"];
        posAudience = _config["JWT:AUDIENCES:POS"];
        mobileAudience = _config["JWT:AUDIENCES:MOBILE"];
    }

    public string GenerateJwtToken(UserDomain user, string platform, IList<string> roles)
    {
        SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
        SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        string? audience = platform.Trim().ToLower() switch
        {
            "web" => webAudience,
            "mobile" => mobileAudience,
            _ => throw new Exception("Invalid platform")
        };

        List<Claim> claims = new List<Claim>
        {
             new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
             new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
             new Claim(JwtRegisteredClaimNames.Iss, jwtIssuer),
             new Claim(JwtRegisteredClaimNames.Aud, audience),
             new Claim(ClaimTypes.Name, user.UserName),
             new Claim(ClaimTypes.NameIdentifier, user.Id),
             new Claim("platform", platform.ToLower())
        };

        foreach (var role in roles)
            claims.Add(new Claim(ClaimTypes.Role, role));

        JwtSecurityToken token = new JwtSecurityToken(
            issuer: jwtIssuer,
            audience: audience,
            claims: claims,
            expires: DateTime.UtcNow.AddHours(8),
            signingCredentials: creds
            );
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
