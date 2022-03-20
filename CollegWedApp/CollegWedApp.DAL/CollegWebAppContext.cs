using CollegWebApp.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CollegWebApp.DAL
{
    public class CollegWebAppContext : DbContext
    {
        public CollegWebAppContext(DbContextOptions<CollegWebAppContext> options)
            : base(options)
        {
            //Database.EnsureCreated();
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Profession> Professions { get; set;}
        public DbSet<Group> Groups { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasOne(a => a.Group)
                .WithMany(b => b.Students);


            modelBuilder.Entity<Profession>()
                .HasMany(p => p.Groups);

        }
    }
}
