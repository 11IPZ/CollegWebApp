using Microsoft.EntityFrameworkCore;
using CollegeApp.Models;

namespace CollegeApp.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Group> Groups { get; set; }
        // public DbSet<Admin> Admins { get; set; }
        public DbSet<Role> Roles { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            string adminRoleName = "admin";
            string strudentRoleName = "student";
 
            string adminEmail = "admin@gmail.com";
            string adminPassword = "123456";
 
            // добавляем роли
            Role adminRole = new Role { Id = 1, Name = adminRoleName };
            Role studentRole = new Role { Id = 2, Name = strudentRoleName };
            // Admin adminUser = new Admin { Id = 1, Email = adminEmail, Password = adminPassword, RoleId = adminRole.Id };
 
            modelBuilder.Entity<Role>().HasData(new Role[] { adminRole, studentRole });
            // modelBuilder.Entity<Admin>().HasData( new Admin[] { adminUser });
            base.OnModelCreating(modelBuilder);
        }
    }
}