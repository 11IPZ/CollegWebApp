using CollegWebApp.Domain.Models;

namespace CollegWebApp.Domain.ViewModels
{
    public class CreateUserViewModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string UserSurname { get; set; }
        public string UserMiddleName { get; set; }
        public DateTime UserDataOfBirth { get; set; }
        public int UserGroupId { get; set; }
    }
}
