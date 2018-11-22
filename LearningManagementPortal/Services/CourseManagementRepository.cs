using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearningManagementPortal.Models;

namespace LearningManagementPortal.Services
{
    public class CourseManagementRepository : ICourseManagementRepository
    {
        private readonly TestDB_MaremaneTPContext _context;

        public CourseManagementRepository(TestDB_MaremaneTPContext context)
        {
            _context = context;
        }
        public void InsertStudent(Course course)
        {
            _context.Course.Add(course);
        }
    }
}
