using System.ComponentModel.DataAnnotations;

namespace CollegWebApp.Domain.Models
{
    public class GroupUser
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int GroupId { get; set; }
    }
}
