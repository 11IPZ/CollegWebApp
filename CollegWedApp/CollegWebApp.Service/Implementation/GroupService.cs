using CollegWebApp.DAL.Interfaces;
using CollegWebApp.Domain.Enums;
using CollegWebApp.Domain.Models;
using CollegWebApp.Domain.Response;
using CollegWebApp.Service.Interfaces;

namespace CollegWebApp.Service.Implementation
{
    public class GroupService : IGroupService
    {
        private readonly IGroupRepository groupRepository;
        public GroupService(IGroupRepository _groupRepository)
        {
            groupRepository = _groupRepository;
        }

        public async Task<IBaseResponse<bool>> Create(Group group)
        {
            var baseResponse = new BaseResponse<bool>();

            try
            {
                bool result = groupRepository.Create(group);

                if (result)
                {
                    baseResponse.Description = "Не вдалось создати групу";
                    baseResponse.Data = result;
                    baseResponse.StatusCode = StatusCode.OK;
                    return baseResponse;
                }

                baseResponse.Data = result;
                baseResponse.StatusCode = StatusCode.OK;

                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>()
                {
                    Description = $"[CreateGroup] : {ex.Message}"
                };
            }
        }

        public Task<IBaseResponse<bool>> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IBaseResponse<IEnumerable<Group>>> GetAll()
        {
            var baseResponse = new BaseResponse<IEnumerable<Group>>();

            try
            {
                IEnumerable<Group> groups = groupRepository.GetAll();

                if (groups is null)
                {
                    baseResponse.Description = "Не вдалось загрузити групи";
                    baseResponse.Data = groups;
                    baseResponse.StatusCode = StatusCode.OK;
                    return baseResponse;
                }

                baseResponse.Data = groups;
                baseResponse.StatusCode = StatusCode.OK;

                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<Group>> ()
                {
                    Description = $"[GetAllGroups] : {ex.Message}"
                };
            }
        }

        public Task<IBaseResponse<IEnumerable<Group>>> GetByYear(int year)
        {
            throw new NotImplementedException();
        }
    }
}
