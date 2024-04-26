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

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);

                modelBuilder.Entity<Car>()
                    .HasOne<Category>(r => r.Category)
                    .WithMany(c => c.Cars)
                    .HasForeignKey(r => r.CategoryID);

                modelBuilder.Entity<Rental>()
                    .HasOne<User>(l => l.User)
                    .WithMany(u => u.Rentals)
                    .HasForeignKey(l => l.UserID);

                modelBuilder.Entity<Rental>()
                    .HasOne<Car>(l => l.Car)
                    .WithMany(r => r.Rentals)
                    .HasForeignKey(l => l.CarID);

               modelBuilder.Entity<Sale>()
                  .HasOne<Car>(e => e.Car)
                  .WithMany(r => r.Sales)
                  .HasForeignKey(e => e.CarID);
            }
        
        }
}
