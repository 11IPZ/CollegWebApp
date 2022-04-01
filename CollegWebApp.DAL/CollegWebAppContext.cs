using CollegWebApp.Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CollegWebApp.DAL
{
    public class CollegWebAppContext : IdentityDbContext<User>
    {
        public CollegWebAppContext(DbContextOptions<CollegWebAppContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Group> Groups { get; set; }
        public DbSet<Lesson> Lessons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne(a => a.UserGroup)
                .WithMany(b => b.Users);

            modelBuilder.Entity<Lesson>()
                .HasMany(a => a.Groups)
                .WithMany(b => b.GroupLessons);
        }
    }
}
