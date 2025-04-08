using Microsoft.EntityFrameworkCore;
using CarSharingAPI.Models;

namespace CarsAPIWebApp.Models
{
    public class CarsAPIContext : DbContext
    {
        public CarsAPIContext(DbContextOptions<CarsAPIContext> options) : base(options) { }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Rent> Rents { get; set; }
        public DbSet<CarSharingZone> CarSharingZones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Зв’язок Car -> Model
            modelBuilder.Entity<Car>()
                .HasOne(c => c.Model)
                .WithMany(m => m.Cars)
                .HasForeignKey(c => c.CR_MODEL_ID);

            // Зв’язок Rent -> Car
            modelBuilder.Entity<Rent>()
                .HasOne(r => r.Car)
                .WithMany(c => c.Rents)
                .HasForeignKey(r => r.RN_CAR_ID);

            // Зв’язок Rent -> Customer
            modelBuilder.Entity<Rent>()
                .HasOne(r => r.Customer)
                .WithMany(c => c.Rents)
                .HasForeignKey(r => r.RN_CS_ID);

            // Устанавливаем точность и масштаб для поля RN_COST_PER_DAY
            modelBuilder.Entity<Rent>()
                .Property(r => r.RN_COST_PER_DAY)
                .HasColumnType("decimal(18,2)"); // Точность 18, масштаб 2
        }
    }
}
