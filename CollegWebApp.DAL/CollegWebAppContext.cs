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
        public DbSet<GroupUser> GroupUsers { get; set; }
        public DbSet<Profession> Professions { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Lesson>()
                .HasMany(a => a.Groups)
                .WithMany(b => b.Lessons);

            modelBuilder.Entity<Profession>()
                .HasMany(a => a.Groups);

            modelBuilder.Entity<GroupUser>()
                .HasKey(a => a.Id);

            modelBuilder.Entity<Group>()
                .HasOne(a => a.Profession)
                .WithMany(b => b.Groups);

        }
    }
}
