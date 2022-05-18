using DataAccess.Models.Base;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public class Course : EntityBase
    {
        public Course()
        {
            CourseToUsers = new List<CourseToUser>();
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImgUrl { get; set; }
        public List<CourseToUser> CourseToUsers { get; set; }
    }
}
