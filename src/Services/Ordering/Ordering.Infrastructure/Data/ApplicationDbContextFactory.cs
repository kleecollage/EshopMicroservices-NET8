using Microsoft.EntityFrameworkCore.Design;

namespace Ordering.Infrastructure.Data;

public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

        optionsBuilder.UseSqlServer(
            "Server=localhost;Database=OrderingDb;User Id=sa;Password=Admin123*;TrustServerCertificate=True");

        return new ApplicationDbContext(optionsBuilder.Options);
    }
}
