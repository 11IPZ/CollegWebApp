using CollegWebApp.Domain.Models;
using CollegWebApp.Domain.ViewModels;

namespace CollegWebApp.DAL.Interfaces
{
    public interface IProfessionRepository : IBaseRepository<Profession>
    {
        public Task<List<Profession>> GetAll();
    }
}
