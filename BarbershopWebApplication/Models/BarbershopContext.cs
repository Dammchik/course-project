using Microsoft.EntityFrameworkCore;

namespace BarbershopWebApplication.Models
{
    public class BarbershopContext : DbContext
    {
        public DbSet<Barber> Barbers { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=barbeshopdb;Username=dammchik;Password=123");
    }
}
