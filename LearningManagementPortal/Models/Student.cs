using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LearningManagementPortal.Models
{
    public partial class Student
    {
        public Student()
        {
            StudentCourse = new HashSet<StudentCourse>();
        }

        public int StudentId { get; set; }
        [Required(ErrorMessage = "First Name is a required field")]
        [Display(Name = "First Name ")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Surname is a required field")]
        [Display(Name = "Surname")]
        public string Surname { get; set; }
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }
        [Display(Name = "ID Number")]
        public string Idnumber { get; set; }
        [Display(Name = "Student Number")]
        public string StudentNumber { get; set; }

        public ICollection<StudentCourse> StudentCourse { get; set; }
    }
}
