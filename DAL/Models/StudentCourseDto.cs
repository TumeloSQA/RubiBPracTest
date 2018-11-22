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
        [Key]
        public int StudentCourseID { get; set; }
        public int CourseId { get; set; }
        
        public int StudentId { get; set; }
    }
}
