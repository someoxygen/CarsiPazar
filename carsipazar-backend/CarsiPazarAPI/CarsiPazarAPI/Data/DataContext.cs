using CarsiPazarAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CarsiPazarAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        //public DbSet<Value> Values { get; set; }
        public DbSet<User> users { get; set; }
        //public DbSet<City> Cities { get; set; }
        //public DbSet<Photo> Photos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .ToTable("users")
                .Property(u => u.UserName)
                .HasColumnName("username");

            modelBuilder.Entity<User>()
                .ToTable("users")
                .Property(u => u.PasswordHash)
                .HasColumnName("passwordhash");

            modelBuilder.Entity<User>()
                .ToTable("users")
                .Property(u => u.PasswordSalt)
                .HasColumnName("passwordsalt");

            modelBuilder.Entity<User>()
                .ToTable("users")
                .Property(u => u.Id)
                .HasColumnName("id");

            base.OnModelCreating(modelBuilder);
        }
    }
}
