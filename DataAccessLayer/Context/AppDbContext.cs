using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Context
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}

        public DbSet<Dish> _dishes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<AppUser>(u =>
            {
                u.Property(user => user.PhoneNumber)
                        .HasMaxLength(15);

                u.Property(user => user.PasswordHash)
                        .HasMaxLength(128);

                u.Property(user => user.ConcurrencyStamp)
                        .HasMaxLength(36);

                u.Property(user => user.SecurityStamp)
                        .HasMaxLength(36);

            });
        }
    }
}
