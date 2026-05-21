using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RaizesDoNordeste.Domain.Repositories;
using RaizesDoNordeste.Domain.Security.Criptography;
using RaizesDoNordeste.Domain.Security.Tokens;
using RaizesDoNordeste.Infrastructure.DataAccess;
using RaizesDoNordeste.Infrastructure.DataAccess.Repositories;
using RaizesDoNordeste.Infrastructure.Security.Tokens;

namespace RaizesDoNordeste.Infrastructure;

public static class DependencyInjectionExtension
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        AddBcrypt(services);
        AddDbContext(services, configuration);
        AddRepositories(services);
        AddToken(services, configuration);
    }

    private static void AddBcrypt(IServiceCollection services) =>
        services.AddScoped<IPasswordEncrypter, Security.Cryptography.BCrypt>();

    private static void AddToken(IServiceCollection services, IConfiguration configuration)
    {
        var expirationTimeMinutes = configuration.GetValue<uint>("Settings:Jwt:ExpiresMinutes");
        var signingKey = configuration.GetValue<string>("Settings:Jwt:SigningKey");

        services.AddScoped<IAccessTokenGenerator>(config => new JwtTokenGenerator(expirationTimeMinutes, signingKey!));
    }

    private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Connection");
        services.AddDbContext<RaizesDoNordesteDbContext>(config => config.UseSqlServer(connectionString));
    }

    private static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfOWork>();
        services.AddScoped<IUsuarioWriteOnlyRepository, UsuarioRepository>();
        services.AddScoped<IUsuarioReadOnlyRepository, UsuarioRepository>();
        services.AddScoped<IRefreshTokenReadOnlyRepository, RefreshTokenRepository>();
        services.AddScoped<IRefreshTokenWriteOnlyRepository, RefreshTokenRepository>();
        services.AddScoped<IUnidadeReadOnlyRepository, UnidadeRepository>();
    }
}