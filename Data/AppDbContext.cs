using event_mgt_server.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace event_mgt_server.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<User> users { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<UserEvent> userEvents { get; set; }
        public DbSet<Ticket> tickets { get; set; }
        public DbSet<Event> events { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed Admin User
            var admin = new User
            {
                Id = 1,
                UserName = "admin",
                Email = "admin@test.com",
                Password = BCrypt.Net.BCrypt.HashPassword("admin123"),
                Role = "Admin"
            };
            modelBuilder.Entity<User>().HasData(admin);
        }
    }
}
