using System.ComponentModel.DataAnnotations;

namespace CollegWeb.Domain.Models
{
    public class GroupUserApp
    {
        [Key]
        public int Id { get; set; }
        public int GroupId { get; set; }
        public string UserId { get; set; }
    }
}
