using CollegWeb.Domain.Response;

namespace CollegWeb.DAL.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task<BaseResponse<int>> Create(T entity);
        Task<BaseResponse<T>> GetById(int id);
        Task<BaseResponse<bool>> Delete(T entity);
        Task<BaseResponse<bool>> Update(T entity);
    }
}
