using System.ComponentModel.DataAnnotations;

namespace CollegWebApp.Domain.Models
{
    public class Profession
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        /*public virtual ICollection<User>? Users { get; set; }
        public virtual ICollection<Group>? Groups { get; set; }*/
    }
}
