namespace CollegWebApp.DAL.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task<bool> CreateAsync(T entity);
        Task<bool> Update(T entity);
        Task<T> GetById(int id);
        Task<T> GetByName(string name);
        Task<bool> Delete(int id);
    }
}
