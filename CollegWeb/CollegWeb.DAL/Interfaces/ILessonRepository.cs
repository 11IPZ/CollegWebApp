using CollegWeb.Domain.Models;
using CollegWeb.Domain.Response;

namespace CollegWeb.DAL.Interfaces
{
    public interface ILessonRepository : IBaseRepository<Lesson>
    {
        Task<BaseResponse<ICollection<Lesson>>> GetLessonsByGroupId(int groupId);
    }
}
