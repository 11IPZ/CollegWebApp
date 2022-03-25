using System.ComponentModel.DataAnnotations;

namespace CollegWebApp.Domain.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string MiddleName { get; set; }
        [Required]
        public virtual Group Group { get; set; }
        public DateTime DateBorn { get; set; }
    }
}
