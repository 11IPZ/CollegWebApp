using CollegWebApp.DAL.Interfaces;
using CollegWebApp.Domain.Models;

namespace CollegWebApp.DAL.Repositories
{
    public class LessonRepository : ILessonRepository
    {
        private readonly CollegWebAppContext _appContext;
        public LessonRepository(CollegWebAppContext appContext)
        {
            _appContext = appContext;
        }
        public bool Create(Lesson entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Lesson> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Lesson GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool Update(Lesson entity)
        {
            throw new NotImplementedException();
        }
    }
}
