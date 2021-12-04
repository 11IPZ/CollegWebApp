// using System.ComponentModel.DataAnnotations;
 
// namespace CollegeApp.Models
// {
//     public class RegisterAdminModel
//     {
//         [Required(ErrorMessage = "Не вказано ім'я")]
//         public string Name { get; set; }

//         [Required(ErrorMessage = "Не вказано фамілію")]
//         public string Uname { get; set; }

//         [Required(ErrorMessage = "Не вказаний Email")]
//         public string Email { get; set; }
 
//         [Required(ErrorMessage = "Не вказаний пароль")]
//         [DataType(DataType.Password)]
//         public string Password { get; set; }
 
//         [DataType(DataType.Password)]
//         [Compare("Password", ErrorMessage = "Пароль введено неправильно")]
//         public string ConfirmPassword { get; set; }
//     }
// }