using CollegWebApp.Domain.Models;


namespace CollegWebApp.DAL.Interfaces
{
    public interface IStudentRepository : IBaseRepository<Student>
    {
        IEnumerable<Student> GetByGroup(int groupId);
        IEnumerable<Student> GetByCours(int course);
        IEnumerable<Student> GetByGrades(int grades, bool? more);
    }
}
