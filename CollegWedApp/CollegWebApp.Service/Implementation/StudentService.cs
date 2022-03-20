using CollegWebApp.DAL.Repositories;
using CollegWebApp.Domain.Models;
using CollegWebApp.Domain.Enums;
using CollegWebApp.Domain.Response;
using CollegWebApp.Service.Interfaces;

namespace CollegWebApp.Service.Implementation
{
    public class StudentService : IStudentService
    {
        private readonly StudentRepository studentRepository;
        public StudentService(StudentRepository _studentRepository)
        {
            studentRepository = _studentRepository;
        }

        public async Task<IBaseResponse<bool>> Create(Student student)
        {
            var baseResponse = new BaseResponse<bool>();

            try
            {
                bool result = studentRepository.Create(student);

                if (result)
                {
                    baseResponse.Description = "Не вдалось создати модель";
                    baseResponse.Data = result;
                    baseResponse.StatusCode = StatusCode.OK;
                    return baseResponse;
                }
                
                baseResponse.Data = result;
                baseResponse.StatusCode = StatusCode.OK;

                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>()
                {
                    Description = $"[CreateStudent] : {ex.Message}"
                };
            }
        }

        public async Task<IBaseResponse<bool>> Delete(int id)
        {
            var baseResponse = new BaseResponse<bool>();

            try
            {
                bool result = studentRepository.Delete(id);

                if (result)
                {
                    baseResponse.Description = "Не видадено";
                    baseResponse.Data = false;
                    baseResponse.StatusCode = StatusCode.OK;
                    return baseResponse;
                }

                baseResponse.Data = result;
                baseResponse.StatusCode = StatusCode.OK;

                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>()
                {
                    Description = $"[DeleteStudent] : {ex.Message}"
                };
            }
        }

        public async Task<IBaseResponse<Student>> GetById(int id)
        {
            var baseResponse = new BaseResponse<Student>();

            try
            {
                var student = await studentRepository.GetById(id);
                if(student is null)
                {
                    baseResponse.Description = "Найдено 0 студентів";
                    baseResponse.StatusCode = StatusCode.OK;
                    return baseResponse;
                }

                baseResponse.Data = student;
                baseResponse.StatusCode = StatusCode.OK;


                return baseResponse;
            }catch(Exception ex)
            {
                return new BaseResponse<Student>()
                {
                    Description = $"[GetByGroup] : {ex.Message}"
                };
            }
        }
    }
}
