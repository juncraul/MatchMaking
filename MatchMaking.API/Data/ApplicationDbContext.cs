using MatchMaking.API.Models;
using Microsoft.EntityFrameworkCore;

namespace MatchMaking.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Sex).IsRequired().HasMaxLength(10);
                entity.Property(e => e.PicturePath).HasMaxLength(500);
                entity.Property(e => e.Score).HasDefaultValue(0);
            });
        }
    }
}
