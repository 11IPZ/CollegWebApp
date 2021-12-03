using System.Collections.Generic;

namespace CollegeApp.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Student> Users { get; set; }
        public Role()
        {
            Users = new List<Student>();
        }
    }
}