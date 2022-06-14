using System.ComponentModel.DataAnnotations;

namespace CollegWeb.Domain.Models
{
    public class Lesson
    {
        public int Id { get; set; }
        [StringLength(150)]
        public string Title { get; set; }
        public string HtmlContext { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateTimeCreate { get; set; }

        public int GroupId { get; set; }
    }
}
