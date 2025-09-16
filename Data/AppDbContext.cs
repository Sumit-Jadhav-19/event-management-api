using event_mgt_server.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace event_mgt_server.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
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
