using CollegWeb.Domain.Models;
using CollegWeb.Domain.Response;

namespace CollegWeb.DAL.Interfaces
{
    public interface IGroupRepository : IBaseRepository<Group>
    {
        Task<BaseResponse<ICollection<Group>>> GetGroupsByUserId(string id);
    }
}
