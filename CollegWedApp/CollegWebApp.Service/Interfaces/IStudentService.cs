using CollegWebApp.Domain.Models;
using CollegWebApp.Domain.Response;

namespace CollegWebApp.Service.Interfaces
{
    public interface IStudentService
    {
        Task<IBaseResponse<Student>> GetById(int id);

        Task<IBaseResponse<bool>> Create(Student student);
        Task<IBaseResponse<bool>> Delete(int id);
    }
}
