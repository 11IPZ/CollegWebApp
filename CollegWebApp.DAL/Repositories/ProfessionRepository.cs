using CollegWebApp.DAL.Interfaces;
using CollegWebApp.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CollegWebApp.DAL.Repositories
{
    public class ProfessionRepository : IProfessionRepository
    {
        private readonly CollegWebAppContext _appContext;
        public ProfessionRepository(CollegWebAppContext appContext)
        {
            _appContext = appContext;
        }
        public async Task<bool> CreateAsync(Profession entity)
        {
            try
            {
                await _appContext.Professions.AddAsync(entity);

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
                using(var ap = _appContext)
                {
                    var profession = new Profession { Id = id };
                    ap.Professions.Attach(profession);
                    ap.Professions.Remove(profession);

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

        public async Task<Profession> GetById(int id)
        {
            try
            {
                var profession = await _appContext.Professions.FirstOrDefaultAsync(p => p.Id == id);

                if (profession == null)
                {
                    return null;
                }
                else
                {
                    return profession;
                }
            }catch (Exception)
            {
                return null;
            }
        }

        public async Task<Profession> GetByName(string name)
        {
            try
            {
                Profession profession = await _appContext.Professions.FirstOrDefaultAsync(p => p.Name == name);

                if (profession == null)
                {
                    return null;
                }
                else
                {
                    return profession;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<bool> Update(Profession entity)
        {
            try
            {
                _appContext.Entry(await _appContext.Professions.FirstOrDefaultAsync(x => x.Id == entity.Id))
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
