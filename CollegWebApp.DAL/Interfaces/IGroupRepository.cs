using CollegWebApp.Domain.Models;

namespace CollegWebApp.DAL.Interfaces
{
    public interface IGroupRepository : IBaseRepository<Group>
    {
        public Task<List<Group>> GetAll();
        public Task<List<string>> FindUsers(int GroupId);
        public Task<bool> AddUser(string UserId, int GroupId);
        public Task<bool> EditUserGroup(string UserId, int LastGroupId, int NewGroupId);
    }
}
