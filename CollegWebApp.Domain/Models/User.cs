using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace CollegWebApp.Domain.Models
{
    public class User : IdentityUser
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Ім'я не може бути більше 50 символів.")]
        [StringLength(50)]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Прізвище не може бути більше 50 символів.")]
        [StringLength(50)]
        public string UserSurname { get; set; }
        [Required(ErrorMessage = "Побатькові не може бути більше 50 символів.")]
        [StringLength(50)]
        public string UserMiddleName { get; set; }
        [DataType(DataType.Date)]
        public DataType UserDataOfBirth { get; set; }
        public virtual Group UserGroup { get; set; }


        /*public List<IdentityRole> AllRoles { get; set; }
        public IList<string> UserRoles { get; set; }
        public User()
        {
            AllRoles = new List<IdentityRole>();
            UserRoles = new List<string>();
        }*/

    }
}
