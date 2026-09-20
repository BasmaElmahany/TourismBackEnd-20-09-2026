using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Tourism.Infrastructure.Persistence
{
    public class ApplicationDbContextFactory
        : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var directory = Directory.GetCurrentDirectory();

            var configuration = new ConfigurationBuilder()
                .SetBasePath(directory)
                .AddJsonFile(
                    "appsettings.json",
                    optional: false
                )
                .Build();


            var optionsBuilder =
                new DbContextOptionsBuilder<ApplicationDbContext>();


            var connectionString =
                configuration.GetConnectionString("DefaultConnection");


            optionsBuilder.UseSqlServer(connectionString);


            return new ApplicationDbContext(
                optionsBuilder.Options
            );
        }
    }
}