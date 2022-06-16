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
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }

        public DbSet<UserApp> Users { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<GroupUserApp> GroupUsers { get; set; }
        public DbSet<Lesson> Lessons { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Lesson>()
                .HasOne<Group>()
                .WithMany(x => x.Lessons);

        }
    }
}
