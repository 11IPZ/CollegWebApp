using CollegWebApp.DAL.Interfaces;
using CollegWebApp.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CollegWebApp.DAL.Repositories
{
    public class GroupRepository : IGroupRepository
    {
        private readonly CollegWebAppContext _appContext;
        public GroupRepository(CollegWebAppContext appContext)
        {
            _appContext = appContext;
        }
        public async Task<bool> CreateAsync(Group entity)
        {
            try
            {
                await _appContext.Groups.AddAsync(entity);

                if (await _appContext.SaveChangesAsync() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                using (var ap = _appContext)
                {
                    var group = new Group { Id = id };
                    ap.Groups.Attach(group);
                    ap.Groups.Remove(group);

                    if (await ap.SaveChangesAsync() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<Group>> GetAll()
        {
            try
            {
                List<Group> groups = await _appContext.Groups.ToListAsync();
                return groups;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Group> GetById(int id)
        {
            try
            {
                var group = await _appContext.Groups.FirstOrDefaultAsync(p => p.Id == id);

                if (group == null)
                {
                    return null;
                }
                else
                {
                    return group;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Group> GetByName(string name)
        {
            try
            {
                Group group = await _appContext.Groups.FirstOrDefaultAsync(p => p.Name == name);

                if (group == null)
                {
                    return null;
                }
                else
                {
                    return group;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<bool> Update(Group entity)
        {
            try
            {
                _appContext.Entry(await _appContext.Groups.FirstOrDefaultAsync(x => x.Id == entity.Id))
                    .CurrentValues
                    .SetValues(entity);

                if (await _appContext.SaveChangesAsync() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
