using System;

namespace BusinessLogic.Dto.Course
{
    public class SubscribeToCourseDto
    {
        public int CourseId { get; set; }
        public int UserId { get; set; }

        public DateTime StartDate { get; set; }
    }
}

