using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LearningManagementPortal.Models
{
    public partial class Course
    {
        public Course()
        {
            StudentCourse = new HashSet<StudentCourse>();
        }

        public int CourseId { get; set; }
        [Required(ErrorMessage = "Course Name is a required field")]
        [Display(Name = "Course Name ")]
        public string CourseName { get; set; }
        
        [Display(Name = "Start Date ")]
        public DateTime? StartDate { get; set; }
        
        [Display(Name = "End Date ")]
        public DateTime? EndDate { get; set; }
        public string CourseNumber { get; set; }

        public ICollection<StudentCourse> StudentCourse { get; set; }
    }
}
