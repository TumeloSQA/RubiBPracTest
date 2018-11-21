using DAL.DbConnection;
using DAL.Models;
using ServiceModules.ServiceModules;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientModules.ServiceImplementation
{
    public class StudentManagementRepository : IStudentManagementRepository
    {
        private DbConnect dbConn = new DbConnect();
        private readonly PortalDbContext _context;

        public StudentManagementRepository(PortalDbContext context)
        {
            _context = context;
        }
        public DataSet GetStudents()
        {
            dbConn.OpenConnection();

            SqlCommand cmd = new SqlCommand("nsp_getStudents", dbConn.connection);
            
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);

            return dataSet;

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

        public string InsertStudents(Student student)
        {
            dbConn.OpenConnection();

            SqlCommand cmd = new SqlCommand("nsp_insertStudents @FirstName, @Surname, @EmailAddress, @IDNumber", dbConn.connection);
            
            //Insert Student Details
            cmd.Parameters.Add("@FirstName", SqlDbType.VarChar, 50).Value = student.FirstName;
            cmd.Parameters.Add("@Surname", SqlDbType.VarChar, 50).Value = student.Surname;

            if (student.EmailAddress == null)
            {
                cmd.Parameters.Add("@EmailAddress", SqlDbType.VarChar, 50).Value = DBNull.Value;
            }
            else
            {
                cmd.Parameters.Add("@EmailAddress", SqlDbType.VarChar, 50).Value = student.EmailAddress;
            }

            if (student.IDNumber == null)
            {
                cmd.Parameters.Add("@IDNumber", SqlDbType.VarChar, 50).Value = DBNull.Value;
            }
            else
            {
                cmd.Parameters.Add("@IDNumber", SqlDbType.VarChar, 50).Value = student.IDNumber;
            }

            cmd.ExecuteNonQuery();

            string respMessage = student.FirstName + " Added Succesfully";
            return respMessage;
        }
    }
}
