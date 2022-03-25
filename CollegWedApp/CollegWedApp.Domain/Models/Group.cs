using System.ComponentModel.DataAnnotations;

namespace CollegWebApp.Domain.Models
{
    public class Group
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual Profession? Profession { get; set; }
        public virtual ICollection<Student>? Students { get; set; }
        public virtual ICollection<Teacher>? Teachers { get; set; }
        public DateTime? DateCreate { get; set; }
    }
}
