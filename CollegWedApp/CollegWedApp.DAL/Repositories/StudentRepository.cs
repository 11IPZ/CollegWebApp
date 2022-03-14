using CollegWebApp.DAL.Interfaces;
using CollegWebApp.Domain.Models;

namespace CollegWebApp.DAL.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        public bool Create(Student entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Student> GetByCours(int course)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Student> GetByGrades(int grades, bool? more)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Student> GetByGroup(int groupId)
        {
            throw new NotImplementedException();
        }

        public Student GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Student GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool Update(int id)
        {
            throw new NotImplementedException();
        }
    }
}
