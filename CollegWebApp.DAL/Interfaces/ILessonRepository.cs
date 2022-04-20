using CollegWebApp.Domain.Models;

namespace CollegWebApp.DAL.Interfaces
{
    public interface ILessonRepository : IBaseRepository<Lesson>
    {
        public Task<Tuple<int, bool>> Add(Lesson lesson);
        public Task<List<Lesson>> GetAll();
        public Task<List<Lesson>> GetByGroup(int groupId);
        public Task<List<Lesson>> GetByIndexParmtr(List<int> group, string name);
        public Task<List<Lesson>> GetNumberNewest(int number, int groupId);
        public Task<List<int>> GetGroupsByLessonId(int id);
        public Task<bool> AddGroup(int LessonId, List<int> GroupsId);
        public Task<bool> EditGroup(int LessonId, List<int> LastGroupsId, List<int> NewGroupsId);

    }
}
