using Microsoft.AspNetCore.Http;

namespace BusinessLogic.Dto.Course
{
    public class AddCourseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IFormFile File { get; set; }
    }
}
