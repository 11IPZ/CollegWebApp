namespace CollegWebApp.DAL.Interfaces
{
    public interface IBaseRepository<T>
    {
        bool Create(T entity);
        bool Update(int id);
        Task<T> GetById(int id);
        T GetByName(string name);
        bool Delete(int id);
    }
}
