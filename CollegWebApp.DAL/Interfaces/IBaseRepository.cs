namespace CollegWebApp.DAL.Interfaces
{
    public interface IBaseRepository<T>
    {
        bool Create(T entity);
        bool Update(T entity);
        Task<T> GetById(int id);
        T GetByName(string name);
        bool Delete(int id);
    }
}
