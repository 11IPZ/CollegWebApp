using System.Web.Mvc;

namespace CollegWebApp.Domain.ViewModels
{
    public class LessonListViewModel
    {
        public IEnumerable<Models.Lesson> Lessons { get; set; }
        public List<int> GroupsId { get; set; }
        public string Name { get; set; }
    }

}
