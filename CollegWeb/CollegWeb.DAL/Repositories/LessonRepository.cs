using CollegWeb.DAL.Interfaces;
using CollegWeb.Domain.Models;
using CollegWeb.Domain.Response;
using CollegWeb.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace CollegWeb.DAL.Repositories
{
    public class LessonRepository : ILessonRepository
    {
        private const string place = "CollegWeb.DAL.Repositories.LessonRepository";
        private readonly ApplicationContext _context;

        public LessonRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<BaseResponse<int>> Create(Lesson entity)
        {
            var result = new BaseResponse<int>();

            try
            {
                if(entity is not null)
                {
                    await _context.Lessons.AddAsync(entity);

                    if(await _context.SaveChangesAsync() >= 1)
                    {
                        result.Data = entity.Id;
                        result.StatusCode = StatusCode.OK;

                        return result;
                    }
                }

                result.Description = place + nameof(Create);
                result.StatusCode = StatusCode.LessonNotCreated;

                return result;
            }
            catch (Exception c)
            {
                result.Description = place + nameof(Create) + c.Message;
                result.StatusCode = StatusCode.TryCatchError;

                return result;
            }
        }

        public async Task<BaseResponse<bool>> Delete(Lesson entity)
        {
            var result = new BaseResponse<bool>();

            try
            {
                if(entity is not null)
                {
                    _context.Lessons.Remove(entity);

                    if(await _context.SaveChangesAsync() >= 1)
                    {
                        result.Data = true;
                        result.StatusCode = StatusCode.OK;

                        return result;
                    }
                }

                result.Data = true;
                result.Description= place + nameof(Delete);
                result.StatusCode = StatusCode.LessonNotDeleted;

                return result;
            }
            catch (Exception c)
            {
                result.Data = false;
                result.Description = place + nameof(Delete) + c.Message;
                result.StatusCode = StatusCode.TryCatchError;

                return result;
            }
        }

        public async Task<BaseResponse<Lesson>> GetById(int id)
        {
            var result = new BaseResponse<Lesson>();

            try
            {
                if (id != null)
                {
                    Lesson lesson = await _context.Lessons.FirstOrDefaultAsync(x => x.Id == id);

                    if (lesson != null)
                    {
                        result.Data = lesson;
                        result.StatusCode = StatusCode.OK;

                        return result;
                    }
                }

                result.Description = place + nameof(GetById);
                result.StatusCode = StatusCode.LessonNotFound;

                return result;
            }
            catch (Exception c)
            {
                result.Description = place + nameof(GetById) + c.Message;
                result.StatusCode = StatusCode.TryCatchError;

                return result;
            }
        }

        public async Task<BaseResponse<ICollection<Lesson>>> GetLessonsByGroupId(int groupId)
        {
            var result = new BaseResponse<ICollection<Lesson>>();

            try
            {
                if (groupId != null)
                {
                    ICollection<Lesson> lessons = await _context.Lessons.Where(x => x.GroupId == groupId).ToArrayAsync();

                    if(lessons.Count() != 0)
                    {
                        result.Data = lessons;
                        result.StatusCode = StatusCode.OK;

                        return result;
                    }
                }

                result.Description = place + nameof(GetLessonsByGroupId);
                result.StatusCode = StatusCode.LessonNotFound;

                return result;
            }
            catch (Exception c)
            {
                result.Description = place + nameof(GetLessonsByGroupId) + c.Message;
                result.StatusCode = StatusCode.TryCatchError;

                return result;
            }
        }

        public async Task<BaseResponse<bool>> Update(Lesson entity)
        {
            var result = new BaseResponse<bool>();

            try
            {
                if (entity is not null)
                {
                    _context.Lessons.Update(entity);

                    if (await _context.SaveChangesAsync() >= 1)
                    {
                        result.Data = true;
                        result.StatusCode = StatusCode.OK;

                        return result;
                    }
                }

                result.Description = place + nameof(Update);
                result.StatusCode = StatusCode.LessonNotUpdated;

                return result;
            }
            catch (Exception c)
            {
                result.Description = place + nameof(Update) + c.Message;
                result.StatusCode = StatusCode.TryCatchError;

                return result;
            }
        }
    }
}
