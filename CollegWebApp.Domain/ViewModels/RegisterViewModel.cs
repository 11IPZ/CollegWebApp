using System.ComponentModel.DataAnnotations;

namespace CollegWebApp.Domain.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Імя")]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Прізвище")]
        [StringLength(50)]
        public string UserSurname { get; set; }

        [Required]
        [Display(Name = "Побатькові")]
        [StringLength(50)]
        public string UserMiddleName { get; set; }

        [Required]
        [Display(Name = "Дата народження")]
        public DateTime UserDataOfBirth { get; set; }

        [Required]
        [Display(Name = "Група")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM}", ApplyFormatInEditMode = true)]
        public int UserGroupId { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Паролі не співпадають")]
        [DataType(DataType.Password)]
        [Display(Name = "Підтвердіть пароль")]
        public string PasswordConfirm { get; set; }
    }
}
