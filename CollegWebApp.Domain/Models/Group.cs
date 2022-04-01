using System.ComponentModel.DataAnnotations;

namespace CollegWebApp.Domain.Models
{
    public class Group
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<User>? Users { get; set; }
        public virtual ICollection<Lesson>? GroupLessons { get; set; }
    }
}
