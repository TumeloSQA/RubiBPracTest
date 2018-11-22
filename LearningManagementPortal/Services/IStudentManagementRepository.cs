using LearningManagementPortal.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace LearningManagementPortal.Services
{
    public interface IStudentManagementRepository
    {
        IEnumerable<Student> GetStudents();
        void InsertStudent(Student student);
        DataSet StudentDetails(int studentId);
    }
}
