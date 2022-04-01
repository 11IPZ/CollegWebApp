using CollegWebApp.DAL.Interfaces;
using CollegWebApp.Domain.Models;

namespace CollegWebApp.DAL.Repositories
{
    public class GroupRepository : IGroupRepository
    {
        private readonly CollegWebAppContext _appContext;
        public GroupRepository(CollegWebAppContext appContext)
        {
            _appContext = appContext;
        }
        public bool Create(Group entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Group> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Group GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool Update(Group entity)
        {
            throw new NotImplementedException();
        }
    }
}
