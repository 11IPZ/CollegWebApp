using CollegWebApp.Domain.Models;

namespace CollegWebApp.DAL.Interfaces
{
    public interface ILessonRepository : IBaseRepository<Lesson>
    {
        Task<ICollection<Lesson>> GetAll(int groupId);
        Task<ICollection<Lesson>> GetNumberNewest(int number, int groupId);
    }
}
