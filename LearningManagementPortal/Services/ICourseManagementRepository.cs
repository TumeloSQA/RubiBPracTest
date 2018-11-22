using LearningManagementPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearningManagementPortal.Services
{
    public interface ICourseManagementRepository
    {
        void InsertStudent(Course course);
    }
}
