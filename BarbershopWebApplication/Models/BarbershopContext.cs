using Microsoft.EntityFrameworkCore;

namespace BarbershopWebApplication.Models
{
    public class BarbershopContext : DbContext
    {
        public DbSet<Barber> Barbers { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Recording> Recordings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Host=localhost;Port=15432;Database=barbershopdb;Username=postgres;Password=postgres");
    }
}
