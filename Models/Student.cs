using System;
using System.ComponentModel.DataAnnotations;


namespace CollegeApp.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Не вказано ім'я")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Не вказано фамілію")]
        public string Uname { get; set; }

        [Required(ErrorMessage = "Не вказаний Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Не вказаний пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Не вказано групу")]
        public Group StudentGroup { get; set; }

        public int? RoleId { get; set; }
        public Role Role { get; set; }
    }
}