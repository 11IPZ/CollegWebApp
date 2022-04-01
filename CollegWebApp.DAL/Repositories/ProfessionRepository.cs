using CollegWebApp.DAL.Interfaces;
using CollegWebApp.Domain.Models;

namespace CollegWebApp.DAL.Repositories
{
    public class ProfessionRepository : IProfessionRepository
    {
        private readonly CollegWebAppContext _appContext;
        public ProfessionRepository(CollegWebAppContext appContext)
        {
            _appContext = appContext;
        }
        public bool Create(Profession entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Profession> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Profession GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool Update(Profession entity)
        {
            throw new NotImplementedException();
        }
    }
}
