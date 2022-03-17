using System.ComponentModel.DataAnnotations;

namespace CollegWebApp.Domain.Models
{
    public class Profession
    {
        [Key]
        public int Id { get; set; }
        public virtual ICollection<Group> Groups { get; set;}
        public string Name { get; set; }
    }
}
