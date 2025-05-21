using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using DotNetEnv;

namespace ProdutosData;

public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        Env.Load();

        var dbUser = Environment.GetEnvironmentVariable("DB_USER");
        var dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD");
        var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
        var dbPort = Environment.GetEnvironmentVariable("DB_PORT");
        var dbService = Environment.GetEnvironmentVariable("DB_SERVICE");
        Console.WriteLine($"Conectando com: User Id={dbUser}; Password={(string.IsNullOrEmpty(dbPassword) ? "vazio" : "****")}; Data Source={dbHost}:{dbPort}/{dbService}");

        var connectionString = $"User Id={dbUser};Password={dbPassword};Data Source={dbHost}:{dbPort}/{dbService};";
  
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionsBuilder.UseOracle(connectionString);

        return new AppDbContext(optionsBuilder.Options);
    }
}