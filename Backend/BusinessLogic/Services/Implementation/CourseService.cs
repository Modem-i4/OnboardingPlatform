using BusinessLogic.Dto.Course;
using BusinessLogic.Services.Abstract;
using BusinessLogic.Vm;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Services.Implementation
{
    public class CourseService : ICourseService
    {
        public Task<List<CourseViewModel>> GetAllCourses()
        {
            throw new System.NotImplementedException();
        }

        public Task<CourseViewModel> GetCourseById(int courseId)
        {
            throw new System.NotImplementedException();
        }

        public Task<SubscribeToCourseViewModel> SubscribeToCourse(SubscribeToCourseDto subscribeToCourseDto)
        {
            throw new System.NotImplementedException();
        }
    }
}
