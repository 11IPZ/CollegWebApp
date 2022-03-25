using CollegWebApp.DAL.Interfaces;
using CollegWebApp.Domain.Models;

namespace CollegWebApp.DAL.Repositories
{
    public class GroupRepository : IGroupRepository
    {
        private readonly CollegWebAppContext context;
        public GroupRepository(CollegWebAppContext _context)
        {
            context = _context;
        }

        public bool Create(Group entity)
        {
            try
            {
                if (entity is null)
                {
                    return false;
                }
                else
                {
                    context.Groups.Add(entity);
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Group> GetAll()
        {
            try
            {
                var groups = context.Groups.ToList();
                return groups;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Task<Group> GetById(int id)
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


        public bool Update(Group entity)
        {
            throw new NotImplementedException();
        }
        
    }
}
