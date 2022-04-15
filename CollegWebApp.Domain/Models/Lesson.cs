using System.ComponentModel.DataAnnotations;

namespace CollegWebApp.Domain.Models
{
    public class Lesson
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(150)]
        public string? Description { get; set; }
        public string HtmlContext { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime DateTimeCreate { get; set; }
        public int CreatorId { get; set; }
        public ICollection<Group> Groups { get; set;}
    }
}
