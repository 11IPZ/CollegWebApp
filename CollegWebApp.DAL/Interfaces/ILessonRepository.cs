using CollegWebApp.Domain.Models;

namespace CollegWebApp.DAL.Interfaces
{
    public interface ILessonRepository : IBaseRepository<Lesson>
    {
        public Task<List<Lesson>> GetAll(int groupId);
        public Task<List<Lesson>> GetNumberNewest(int number, int groupId);
        public Task<bool> AddGroup(int LessonId, List<int> GroupsId);
        public Task<bool> EditGroup(int LessonId, List<int> LastGroupsId, List<int> NewGroupsId);

    }
}
