using CollegWeb.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CollegWeb.DAL
{
    public class ApplicationContext : IdentityDbContext<UserApp, IdentityRole, string>
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        public DbSet<UserApp> Users;
        public DbSet<Group> Groups;
        public DbSet<Lesson> Lessons;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Group>()
                .HasMany(g => g.Users)
                .WithMany(g => g.Groups);

            builder.Entity<Lesson>()
                .HasOne<Group>()
                .WithMany(x => x.Lessons);
        }
    }
}
