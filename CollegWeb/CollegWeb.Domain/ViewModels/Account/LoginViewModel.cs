using System.ComponentModel.DataAnnotations;

namespace CollegWeb.Domain.ViewModels.Account
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Display(Name = "Запамятати?")]
        public bool RememberMe { get; set; }

        public string ReturnUrl { get; set; }
    }
}
