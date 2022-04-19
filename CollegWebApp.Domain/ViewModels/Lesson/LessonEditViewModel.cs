using System.ComponentModel.DataAnnotations;

namespace CollegWebApp.Domain.ViewModels.Lesson
{
    public class LessonEditViewModel
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(150)]
        public string? Description { get; set; }
        public string HtmlContext { get; set; }
        public List<int> GroupsId { get; set; }
    }
}
