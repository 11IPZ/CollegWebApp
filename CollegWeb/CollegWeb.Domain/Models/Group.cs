using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CollegWeb.Domain.Models
{
    public class Group
    {
        public int Id { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        public string Code { get; set; }
        public string AdminUserId { get; set; }

        public List<UserApp> Users { get; set; }

        [ForeignKey(nameof(Lesson.GroupId))]
        public ICollection<Lesson> Lessons { get; set; }
    }
}
