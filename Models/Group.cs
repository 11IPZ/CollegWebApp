using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CollegeApp.Models
{
    public class Group
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Не вказано імя групи")]
        public string NameGroup { get; set; }
        // public List<Student> Students { get; set; }
    }
}