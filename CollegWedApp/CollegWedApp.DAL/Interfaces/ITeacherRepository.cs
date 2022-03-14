using CollegWebApp.Domain.Models;

namespace CollegWebApp.DAL.Interfaces
{
    public interface ITeacherRepository : IBaseRepository<Teacher>
    {
        IEnumerable<Teacher> GetAll();
        IEnumerable<Teacher> GetByLesson(int lessonId);
    }
}
