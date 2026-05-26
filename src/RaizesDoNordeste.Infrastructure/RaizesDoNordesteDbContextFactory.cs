using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using RaizesDoNordeste.Infrastructure.DataAccess;

namespace RaizesDoNordeste.Infrastructure;

public class RaizesDoNordesteDbContextFactory : IDesignTimeDbContextFactory<RaizesDoNordesteDbContext>
{
    public RaizesDoNordesteDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<RaizesDoNordesteDbContext>();
        optionsBuilder.UseSqlServer(
            "Server=localhost,1433;Database=master;User Id=sa;Password=p@55w0rd;TrustServerCertificate=True");

        return new RaizesDoNordesteDbContext(optionsBuilder.Options);
    }
}