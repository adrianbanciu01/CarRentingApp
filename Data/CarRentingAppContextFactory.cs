using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;
namespace CarRentingApp.Data
{
    public class CarRentingAppContextFactory : IDesignTimeDbContextFactory<CarRentingAppContext>
    {
        public CarRentingAppContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<CarRentingAppContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("CarRentingAppContext"));

            return new CarRentingAppContext(optionsBuilder.Options);
        }
    }
}
