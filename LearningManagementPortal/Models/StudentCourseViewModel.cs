using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LearningManagementPortal.Models
{
    public class StudentCourseViewModel
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        [Display(Name = "Course Name")]
        public string CourseName { get; set; }
        [Display(Name = "Start Date ")]
        public DateTime? StartDate { get; set; }
        [Display(Name = "End Date ")]
        public DateTime? EndDate { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Surname")]
        public string Surname { get; set; }
        public IEnumerable<Student> Students { get; set; }
        public IEnumerable<Course> Courses { get; set; }
    }
}
