using System.Linq;
using CollegApp.Models;
 
namespace CollegApp
{
    public static class StudentData
    {
        public static void Initialize(CollegeContext context)
        {
            if (!context.Students.Any())
            {
                context.Students.AddRange(
                    new Student
                    {
                        Name = "Oleg",
                        Uname = "Markelov",
                        Group = "11-ІПЗ",
                    },
                    new Student
                    {
                        Name = "Denis",
                        Uname = "Pasichnick",
                        Group = "11-ТТ",
                    },
                    new Student
                    {
                        Name = "Semen",
                        Uname = "Gavrin",
                        Group = "11-ІПЗ",
                    }
                );
                context.SaveChanges();
            }
        }
    }
}