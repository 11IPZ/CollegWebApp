
namespace CollegWebApp.Domain.Models
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string MiddleName { get; set; }
        public ICollection<Group> Groups { get; set; }
        public DateTime DateBorn { get; set; }
    }
}
