using CollegWebApp.DAL.Interfaces;
using CollegWebApp.Domain.Models;

namespace CollegWebApp.DAL.Repositories
{
    public class TeacherRepository : ITeacherRepository
    {
        public TeacherRepository()
        {
        }

        public bool Create(Teacher entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Teacher> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Teacher> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Teacher> GetByLesson(int lessonId)
        {
            throw new NotImplementedException();
        }

        public Teacher GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool Update(Teacher entity)
        {
            throw new NotImplementedException();
        }
    }
}
