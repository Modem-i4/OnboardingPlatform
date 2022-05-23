using BusinessLogic.Dto.Course;
using BusinessLogic.Vm;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Services.Abstract
{
    public interface ICourseService
    {
        Task<List<CourseViewModel>> GetAllCourses();
        Task<CourseViewModel> GetCourseById(int courseId);
        Task<SubscribeToCourseViewModel> SubscribeToCourse(SubscribeToCourseDto subscribeToCourseDto);
        Task<bool> GetIsUserSubscribedToTheCourse(int courseId, int userId);
        Task<List<CourseToUserViewModel>> GetCoursesByUserId(int userId);
        Task<List<CourseToUserViewModel>> GetCoursesByUserEmail(string email);

    }
}
