using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public partial class Course
    {
        public Course()
        {
            this.Students = new HashSet<Student>();
        }
        
        public int CourseId { get; set; }

        [Required(ErrorMessage = "Course Name is a required field")]
        [Display(Name = "Course Name")]
        public string CourseName { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        //public string CourseNumber { get; set; }
        
        public virtual ICollection<Student> Students { get; set; }
    }
}
