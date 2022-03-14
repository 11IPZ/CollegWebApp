using System.ComponentModel.DataAnnotations.Schema;

namespace CollegWebApp.Domain.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string MiddleName { get; set; }
        public Group Group { get; set; }
        public DateTime DateBorn { get; set; }
    }
}
