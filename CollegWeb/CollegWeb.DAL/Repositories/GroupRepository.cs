using CollegWeb.DAL.Interfaces;
using CollegWeb.Domain.Models;
using CollegWeb.Domain.Response;
using CollegWeb.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace CollegWeb.DAL.Repositories
{
    public class GroupRepository : IGroupRepository
    {
        private const string place = "CollegWeb.DAL.Repositories.GroupRepository";
        private readonly ApplicationContext _context;

        public GroupRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<BaseResponse<int>> Create(Group entity)
        {
            var result = new BaseResponse<int>();

            try
            {
                if (entity is not null)
                {
                    if(await _context.Groups.FirstOrDefaultAsync(x => x.Name == entity.Name) != null)
                    {
                        result.Description = place + nameof(Create);
                        result.StatusCode = StatusCode.GroupNotCreated;

                        return result;
                    }

                    await _context.Groups.AddAsync(entity);

                    if (await _context.SaveChangesAsync() >= 1)
                    {
                        result.Data = entity.Id;
                        result.StatusCode = StatusCode.OK;

                        return result;
                    }
                }

                result.Description = place + nameof(Create);
                result.StatusCode = StatusCode.GroupNotCreated;

                return result;
            }
            catch (Exception c)
            {
                result.Description = place + nameof(Create) + c.Message;
                result.StatusCode = StatusCode.TryCatchError;

                return result;
            }
        }

        public async Task<BaseResponse<bool>> CreateGroupUserRelationship(int GroupId, string UserId)
        {
            var result = new BaseResponse<bool>();

            try
            {
                if (GroupId != null && UserId != null)
                {
                    var GroupUserAppList = await _context.GroupUsers.Where(x => x.GroupId == GroupId).ToListAsync();
                    var UserList = GroupUserAppList.Where(x => x.UserId == UserId).ToList();
                    if (UserList.Count() == 0)
                    {
                        var model = new GroupUserApp()
                        {
                            GroupId = GroupId,
                            UserId = UserId
                        };
                        await _context.GroupUsers.AddAsync(model);
                    }

                    if (await _context.SaveChangesAsync() >= 1)
                    {
                        result.Data = true;
                        result.StatusCode = StatusCode.OK;

                        return result;
                    }
                }

                result.Description = place + nameof(Create);
                result.StatusCode = StatusCode.GroupUserRelationshipNotCreated;

                return result;
            }
            catch (Exception c)
            {
                result.Description = place + nameof(Create) + c.Message;
                result.StatusCode = StatusCode.GroupUserRelationshipNotCreated;

                return result;
            }
        }

        public async Task<BaseResponse<bool>> Delete(Group entity)
        {
            var result = new BaseResponse<bool>();

            try
            {
                if (entity is not null)
                {
                    _context.Groups.Remove(entity);

                    if (await _context.SaveChangesAsync() >= 1)
                    {
                        result.Data = true;
                        result.StatusCode = StatusCode.OK;

                        return result;
                    }
                }

                result.Data = true;
                result.Description = place + nameof(Delete);
                result.StatusCode = StatusCode.GroupNotDeleted;

                return result;
            }
            catch (Exception c)
            {
                result.Data = false;
                result.Description = place + nameof(Delete) + c.Message;
                result.StatusCode = StatusCode.TryCatchError;

                return result;
            }
        }

        public async Task<BaseResponse<Group>> GetById(int id)
        {
            var result = new BaseResponse<Group>();

            try
            {
                if (id != null)
                {
                    Group group = await _context.Groups.FirstOrDefaultAsync(x => x.Id == id);

                    if (group != null)
                    {
                        result.Data = group;
                        result.StatusCode = StatusCode.OK;

                        return result;
                    }
                }

                result.Description = place + nameof(GetById);
                result.StatusCode = StatusCode.GroupNotFound;

                return result;
            }
            catch (Exception c)
            {
                result.Description = place + nameof(GetById) + c.Message;
                result.StatusCode = StatusCode.TryCatchError;

                return result;
            }
        }

        public async Task<BaseResponse<ICollection<Group>>> GetGroupsByUserId(string id)
        {
            var result = new BaseResponse<ICollection<Group>>();

            try
            {
                if (id != null)
                {
                    var listIdOfGrops = _context.GroupUsers.Where(x => x.UserId == id).ToList();
                    List<Group> groups = new();
                    foreach (var item in listIdOfGrops)
                    {
                        Group group = await _context.Groups.FirstOrDefaultAsync(x => x.Id == item.GroupId);
                        if(group != null)
                            groups.Add(group);
                    }

                    if (groups.Count() != 0)
                    {
                        result.Data = groups;
                        result.StatusCode = StatusCode.OK;

                        return result;
                    }
                }

                result.Description = place + nameof(GetGroupsByUserId);
                result.StatusCode = StatusCode.GroupNotFound;

                return result;
            }
            catch (Exception c)
            {
                result.Description = place + nameof(GetGroupsByUserId) + c.Message;
                result.StatusCode = StatusCode.TryCatchError;

                return result;
            }
        }

        public async Task<BaseResponse<bool>> Update(Group entity)
        {
            var result = new BaseResponse<bool>();

            try
            {
                if (entity is not null)
                {
                    _context.Groups.Update(entity);

                    if (await _context.SaveChangesAsync() >= 1)
                    {
                        result.Data = true;
                        result.StatusCode = StatusCode.OK;

                        return result;
                    }
                }

                result.Description = place + nameof(Update);
                result.StatusCode = StatusCode.GroupNotDeleted;

                return result;
            }
            catch (Exception c)
            {
                result.Description = place + nameof(Update) + c.Message;
                result.StatusCode = StatusCode.TryCatchError;

                return result;
            }
        }
    }
}
