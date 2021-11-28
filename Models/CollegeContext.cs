using Microsoft.EntityFrameworkCore;
using CollegApp.Models;
 
namespace CollegApp.Models
{
    public class CollegeContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
 
        public CollegeContext(DbContextOptions<CollegeContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}