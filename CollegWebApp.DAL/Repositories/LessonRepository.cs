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

        public async Task<bool> AddGroup(int LessonId, List<int> GroupsId)
        {
            try
            {
                if(GroupsId.Count() != 0 && LessonId != null)
                {
                    foreach(int item in GroupsId)
                    {
                        GroupLesson gl = new GroupLesson()
                        {
                            LessonId = LessonId,
                            GroupId = item,
                        };

                        await _appContext.AddAsync(gl);
                    }

                    if (await _appContext.SaveChangesAsync() > 0)
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
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

        public async Task<bool> EditGroup(int LessonId, List<int> LastGroupsId, List<int> NewGroupsId)
        {
            try
            {
                if (LastGroupsId.Count == 0)
                {
                    bool result = await AddGroup(LessonId, NewGroupsId);

                    if (result)
                        return true;
                }
                else
                {
                    List<GroupLesson> lastGroupsLesson = await _appContext.GroupLessons.Where(x => x.LessonId == LessonId).ToListAsync();

                    if (NewGroupsId.Count != 0)
                    {
                        bool result = await AddGroup(LessonId, NewGroupsId);
                        if(result)
                        {
                            foreach(var groupLesson in lastGroupsLesson)
                            {
                                _appContext.GroupLessons.Remove(groupLesson);

                            }

                            if (await _appContext.SaveChangesAsync() > 0)
                            {
                                return true;
                            }

                        }
                    }
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<Lesson>> GetAll(int groupId)
        {
            try
            {
                if(groupId != null)
                {
                    List<Lesson> lessons = new List<Lesson>();

                    List<GroupLesson> gl = await _appContext.GroupLessons.Where(x => x.GroupId == groupId).ToListAsync();

                    foreach(var l in gl)
                    {
                        Lesson lesson = await _appContext.Lessons.FirstOrDefaultAsync(x => x.Id == l.Id);
                        lessons.Add(lesson);
                    }

                    if(lessons.Count > 0)
                        return lessons;
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
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

        public Task<List<Lesson>> GetNumberNewest(int number, int groupId)
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
