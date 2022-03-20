using CollegWebApp.DAL.Interfaces;
using CollegWebApp.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CollegWebApp.DAL.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly CollegWebAppContext context;
        public StudentRepository(CollegWebAppContext _context)
        {
            context = _context;
        }

        public bool Create(Student entity)
        {
            try
            {
                context.Students.Add(entity);
                context.SaveChanges();
                return true;
            }catch (Exception ex)
            {
                return false;
            }
            
        }

        public bool Delete(int id)
        {
            try
            {
                var student = context.Students.FirstOrDefaultAsync(x => x.Id == id);

                if (student == null)
                {
                    context.Remove(student);
                    context.SaveChanges();
                    return true;
                }

                return false;
            }catch (Exception ex)
            {
                return false;
            }
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

        public Task<Student> GetById(int id)
        {
            return context.Students.FirstOrDefaultAsync(i => i.Id == id);
        }

        public Student GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool Update(Student entity)
        {
            throw new NotImplementedException();
        }
    }
}
