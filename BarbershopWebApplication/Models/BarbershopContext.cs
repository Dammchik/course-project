using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace BarbershopWebApplication.Models
{
    public class BarbershopContext : DbContext
    {
        public BarbershopContext(DbContextOptions<BarbershopContext> options) : base(options)
        {
        }

        public DbSet<Barber> Barbers { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Recording> Recordings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Host=localhost;Port=15432;Database=barbershopdb;Username=postgres;Password=postgres");
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Barber>().HasData(
                new Barber { BarberId = 1, Name = "Иван" },
                new Barber { BarberId = 2, Name = "Пётр" },
                new Barber { BarberId = 3, Name = "Антон" },
                new Barber { BarberId = 4, Name = "Сергей" }
            );

            modelBuilder.Entity<Service>().HasData(
                new Service { ServiceId = 1, Title = "Стрижка машинкой", Price = 800 },
                new Service { ServiceId = 2, Title = "Детская стрижка", Price = 1500 },
                new Service { ServiceId = 3, Title = "Стрижка машинкой Fade", Price = 1600 },
                new Service { ServiceId = 4, Title = "Мужская стрижка", Price = 2100 }
            );
        }
    }
}
