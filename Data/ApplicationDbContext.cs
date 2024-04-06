using CarRent.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarRent.Data
{
    public class ApplicationDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Sale> Sales { get; set; }
    }
}
