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

        public async Task<bool> AddUser(string UserId, int GroupId)
        {
            try
            {
                GroupUser gu = new GroupUser()
                {
                    UserId = UserId,
                    GroupId = GroupId
                };
                await _appContext.AddAsync(gu);

                if (await _appContext.SaveChangesAsync() > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
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

        public async Task<bool> EditUserGroup(string UserId, int LastGroupId, int NewGroupId)
        {
            try
            {
                if (LastGroupId == 0)
                {
                    bool result = await AddUser(UserId, NewGroupId);

                    if (result)
                        return true;
                }
                else
                {
                    GroupUser lastGroupUser = await _appContext.GroupUsers.FirstOrDefaultAsync(x => x.GroupId == LastGroupId);
                    Group newGroup = await _appContext.Groups.FirstOrDefaultAsync(x => x.Id == NewGroupId);

                    if (lastGroupUser != null && newGroup != null)
                    {
                        await AddUser(UserId, NewGroupId);
                        _appContext.GroupUsers.Remove(lastGroupUser);

                        if(await _appContext.SaveChangesAsync() > 0)
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<string>> FindUsers(int GroupId)
        {
            try
            {
                if(GroupId != 0)
                {
                    List<string> usersId = new List<string>();

                    List<GroupUser> gu = _appContext.GroupUsers.Where(i => i.GroupId == GroupId).ToList();
                    if (gu.Count > 0)
                    {
                        foreach (GroupUser item in gu)
                        {
                            usersId.Add(item.UserId);
                        }
                        return usersId;
                    }
                }
                return null;
            }
            catch (Exception)
            {
                return null;
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
