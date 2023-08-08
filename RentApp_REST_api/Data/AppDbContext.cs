using Microsoft.EntityFrameworkCore;
using RentApp_REST_api.Models;

namespace RentApp_REST_api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
        public DbSet<Car> Cars { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>().HasData(
                new Car()
                {
                    Id = 1,
                    Brand = "Toyota",
                    Model = "Camry",
                    Year = 2022,
                    HorsePower = 250,
                    ImageUrl = "",
                    Price = 300,
                    Rating = 5,
                    Description = "",
                    Details = "",
                    CreatedDate = DateTime.Now,
                },
                new Car ()
                {
                    Id = 2,
                    Brand = "Mercedes",
                    Model = "S-Class W223",
                    Year = 2020,
                    HorsePower = 330,
                    ImageUrl = "",
                    Price = 800,
                    Rating = 30,
                    Description = "",
                    Details = "",
                    CreatedDate = DateTime.Now,
                });
        }
    }
}
