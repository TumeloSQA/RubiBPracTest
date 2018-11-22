using LearningManagementPortal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using LearningManagementPortal.DbConnection;

namespace LearningManagementPortal.Services
{
    public class StudentManagementRepository : IStudentManagementRepository
    {
        private DbConnect dbConn = new DbConnect();

        private readonly TestDB_MaremaneTPContext _context;

        public StudentManagementRepository(TestDB_MaremaneTPContext context)
        {
            _context = context;
        }
        public IEnumerable<Student> GetStudents()
        {
            return _context.Student
                .ToList();
        }

        public DataSet StudentDetails(int studentId)
        {
            dbConn.OpenConnection();

            SqlCommand cmd = new SqlCommand("nsp_getStudent_details @studentId", dbConn.connection);

            //Filter Client Details
            cmd.Parameters.Add("@studentId", SqlDbType.Int).Value = studentId;

            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);

            DataSet dataSet = new DataSet();

            dataAdapter.Fill(dataSet);

            return dataSet;
        }

        public void InsertStudent(Student student)
        {
            _context.Student.Add(student);
        }

    }
}
