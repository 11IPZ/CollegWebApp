using Microsoft.AspNetCore.Identity;

namespace CollegWeb.Domain.Models
{
    public class UserApp : IdentityUser
    {

        [PersonalData]
        public string FullName { get; set; }

        public ICollection<Group> Groups { get; set; }
    }
}
