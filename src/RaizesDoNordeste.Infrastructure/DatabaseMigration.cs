using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RaizesDoNordeste.Infrastructure.DataAccess;

namespace RaizesDoNordeste.Infrastructure;

public static class DatabaseMigration
{
    public static async Task MigrateDatabase(IServiceProvider serviceProvider)
    {
        var dbContext = serviceProvider.GetRequiredService<RaizesDoNordesteDbContext>();
        await dbContext.Database.MigrateAsync();
    }
}