using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Postgre.Persistence.EFCore20
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<MainContext>
    {

        public MainContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            
            var builder = new DbContextOptionsBuilder<MainContext>();
            var connectionString = configuration.GetConnectionString("MainContext");
            builder.UseNpgsql(connectionString);
            return new MainContext(builder.Options);
        }
    }
}
