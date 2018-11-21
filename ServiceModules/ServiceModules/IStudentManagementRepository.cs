using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceModules.ServiceModules
{
    public interface IStudentManagementRepository
    {
        DataSet GetStudents();
        DataSet StudentDetails(int studentId);
        string InsertStudents(Student student);
        
    }
}
