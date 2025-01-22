using Microsoft.EntityFrameworkCore;
using CarRentingApp.Models;
using System.Collections.Generic;

namespace CarRentingApp.Data
{
    public class CarRentingAppContext : DbContext
    {
        public CarRentingAppContext(DbContextOptions<CarRentingAppContext> options) : base(options) { }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<Location> Locations { get; set; }
    }
}
