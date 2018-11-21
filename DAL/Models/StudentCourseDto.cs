using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class StudentCourseDto
    {
        public int CourseId { get; set; }

        [Required(ErrorMessage = "Course Name is a required field")]

        [Display(Name = "Course Name")]
        public string CourseName { get; set; }

        public int StudentId { get; set; }

        [Required(ErrorMessage = "First Name is a required field")]
        [Display(Name = "First Name ")]
        public string FirstName { get; set; }
    }
}
