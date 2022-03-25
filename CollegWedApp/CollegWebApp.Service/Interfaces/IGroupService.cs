using CollegWebApp.Domain.Models;
using CollegWebApp.Domain.Response;

namespace CollegWebApp.Service.Interfaces
{
    public interface IGroupService
    {
        Task<IBaseResponse<bool>> Create(Group entity);
        Task<IBaseResponse<bool>> Delete(int id);
        Task<IBaseResponse<IEnumerable<Group>>> GetAll();
        Task<IBaseResponse<IEnumerable<Group>>> GetByYear(int year);
    }
}
