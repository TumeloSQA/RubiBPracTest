using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class StudentCourseViewModel
    {
        public List<Course> Courses { get; set; }
        public List<Student> Students { get; set; }

    }
}
