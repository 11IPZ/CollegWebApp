using CollegWebApp.Domain.Models;

namespace CollegWebApp.DAL.Interfaces
{
    public interface IGroupRepository : IBaseRepository<Group>
    {
        IEnumerable<Group> GetAll();
        IEnumerable<Group> GetByYear(int year);
        IEnumerable<Group> GetByProfession(int professionId);

    }
}
