using DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public partial class Student
    {
        public Student()
        {
            this.Courses = new HashSet<Course>();
        }

        public int StudentId { get; set; }
        [Required(ErrorMessage = "First Name is a required field")]
        [Display(Name = "First Name ")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Surname is a required field")]
        [Display(Name = "Surname")]
        public string Surname { get; set; }
        public string EmailAddress { get; set; }
        public string IDNumber { get; set; }
        //public string StudentNumber { get; set; }
        
        public virtual ICollection<Course> Courses { get; set; }
    }
}
