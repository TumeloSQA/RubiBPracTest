using System;
using System.Collections.Generic;

namespace LearningManagementPortal.Models
{
    public partial class StudentCourse
    {
        public int StudentCourseId { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }

        public Course Course { get; set; }
        public Student Student { get; set; }
    }
}
