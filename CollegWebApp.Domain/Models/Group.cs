using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace CollegWebApp.Domain.Models
{
    public class Group
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public Profession Profession { get; set; }
        public ICollection<Lesson> Lessons { get; set; }
    }
}
