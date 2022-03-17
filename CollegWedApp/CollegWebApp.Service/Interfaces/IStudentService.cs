using CollegWebApp.Domain.Models;
using CollegWebApp.Domain.Response;

namespace CollegWebApp.Service.Interfaces
{
    public interface IStudentService
    {
        Task<IBaseResponse<Student>> GetById(int id);
    }
}
