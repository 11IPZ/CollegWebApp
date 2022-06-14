using System.ComponentModel.DataAnnotations;

namespace CollegWeb.Domain.ViewModels.Group
{
    public class CreateGroupViewModel
    {
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }
    }
}
