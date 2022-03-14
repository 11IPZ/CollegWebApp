using CollegWebApp.DAL.Interfaces;
using CollegWebApp.Domain.Models;

namespace CollegWebApp.DAL.Repositories
{
    public class GroupRepository : IGroupRepository
    {
        public bool Create(Group entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Group> GetAll()
        {
            throw new NotImplementedException();
        }

        public Group GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Group GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Group> GetByProfession(int professionId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Group> GetByYear(int year)
        {
            throw new NotImplementedException();
        }

        public bool Update(int id)
        {
            throw new NotImplementedException();
        }
    }
}
