using CollegWebApp.DAL.Interfaces;
using CollegWebApp.Domain.Models;

namespace CollegWebApp.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly CollegWebAppContext _appContext;
        public UserRepository(CollegWebAppContext appContext)
        {
            _appContext = appContext;
        }

        public async Task<bool> CreateAsync(User entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
