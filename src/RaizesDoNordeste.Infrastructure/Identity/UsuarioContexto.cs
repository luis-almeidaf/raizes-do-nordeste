using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using RaizesDoNordeste.Domain.Entities;
using RaizesDoNordeste.Domain.Identity;
using RaizesDoNordeste.Domain.Security.Tokens;
using RaizesDoNordeste.Infrastructure.DataAccess;

namespace RaizesDoNordeste.Infrastructure.Identity;

public class UsuarioContexto(RaizesDoNordesteDbContext dbContext, ITokenContexto tokenContexto) : IUsuarioContexto
{
    public async Task<Usuario> BuscarUsuarioAutenticado()
    {
        var token = tokenContexto.BuscarToken();

        var tokenHandler = new JwtSecurityTokenHandler();

        var jwtSecurityToken = tokenHandler.ReadJwtToken(token);

        var identificador = jwtSecurityToken.Claims.First(claim => claim.Type == ClaimTypes.NameIdentifier).Value;

        return await dbContext.Usuarios.AsNoTracking().FirstAsync(usuario => usuario.Id == Guid.Parse(identificador));
    }
}