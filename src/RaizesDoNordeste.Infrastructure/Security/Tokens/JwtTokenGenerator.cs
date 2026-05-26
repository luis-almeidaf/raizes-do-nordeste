using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using RaizesDoNordeste.Domain.Entities;
using RaizesDoNordeste.Domain.Security.Tokens;

namespace RaizesDoNordeste.Infrastructure.Security.Tokens;

public class JwtTokenGenerator(uint expiracaoEmMinutos, string chaveAssinatura) : IAccessTokenGenerator
{
    public string GerarTokenJwt(Usuario usuario)
    {
        var claims = new List<Claim>()
        {
            new Claim(ClaimTypes.Name, usuario.Nome),
            new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
            new Claim(ClaimTypes.Role, usuario.Role.ToString()),
        };

        var tokenDescriptor = new SecurityTokenDescriptor()
        {
            Expires = DateTime.UtcNow.AddMinutes(expiracaoEmMinutos),
            SigningCredentials = new SigningCredentials(SecurityKey(), SecurityAlgorithms.HmacSha256Signature),
            Subject = new ClaimsIdentity(claims)
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var securityToken = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(securityToken);
    }

    public string GerarRefreshToken() => Convert.ToBase64String(RandomNumberGenerator.GetBytes(32));

    private SymmetricSecurityKey SecurityKey()
    {
        var key = Encoding.UTF8.GetBytes(chaveAssinatura);
        return new SymmetricSecurityKey(key);
    }
}