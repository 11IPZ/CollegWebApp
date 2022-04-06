using CollegWebApp.Domain.Models;

namespace CollegWebApp.DAL.Interfaces
{
    public interface IGroupRepository : IBaseRepository<Group>
    {
        public Task<List<Group>> GetAll();
    }
}
