using ADStarter.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace ADStarter.DataAccess.Data
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDBContext>
    {
        public ApplicationDBContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDBContext>();

            // Load the configuration from appsettings.json
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath("/Users/hasancheabdullah/Documents/GitHub/FypSystem/ADStarterWeb/")
                .AddJsonFile("appsettings.json")
                .Build();

            // Get the connection string
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            optionsBuilder.UseSqlServer(connectionString);

            return new ApplicationDBContext(optionsBuilder.Options);
        }
    }
}