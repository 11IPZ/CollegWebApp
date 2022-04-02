using CollegWebApp.DAL.Interfaces;
using CollegWebApp.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CollegWebApp.DAL.Repositories
{
    public class LessonRepository : ILessonRepository
    {
        private readonly CollegWebAppContext _appContext;
        public LessonRepository(CollegWebAppContext appContext)
        {
            _appContext = appContext;
        }
        public async Task<bool> CreateAsync(Lesson entity)
        {
            try
            {
                await _appContext.Lessons.AddAsync(entity);

                if (await _appContext.SaveChangesAsync() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                using (var ap = _appContext)
                {
                    var lesson = new Lesson { Id = id };
                    ap.Lessons.Attach(lesson);
                    ap.Lessons.Remove(lesson);

                    if (await ap.SaveChangesAsync() > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Task<ICollection<Lesson>> GetAll(int groupId)
        {
            throw new NotImplementedException();
        }

        public async Task<Lesson> GetById(int id)
        {
            try
            {
                var lesson = await _appContext.Lessons.FirstOrDefaultAsync(p => p.Id == id);

                if (lesson == null)
                {
                    return null;
                }
                else
                {
                    return lesson;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Lesson> GetByName(string name)
        {
            try
            {
                Lesson lesson = await _appContext.Lessons.FirstOrDefaultAsync(p => p.Name == name);

                if (lesson == null)
                {
                    return null;
                }
                else
                {
                    return lesson;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Task<ICollection<Lesson>> GetNumberNewest(int number, int groupId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Update(Lesson entity)
        {
            try
            {
                _appContext.Entry(await _appContext.Lessons.FirstOrDefaultAsync(x => x.Id == entity.Id))
                    .CurrentValues
                    .SetValues(entity);

                if (await _appContext.SaveChangesAsync() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
