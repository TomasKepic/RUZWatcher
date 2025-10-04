using Microsoft.EntityFrameworkCore;
using RUZWatcher.Models;

namespace RUZWatcher.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<UctovnaJednotka> UctovneJednotky { get; set; } = default!;
        public DbSet<UctovnaZavierka> UctovneZavierky { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UctovnaJednotka>()
                .HasMany(u => u.UctovneZavierky)
                .WithOne(z => z.UctovnaJednotka)
                .HasForeignKey(z => z.IdUJ)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}