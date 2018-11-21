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
    public class CourseManagementRepository : ICourseManagementRepository
    {
        private DbConnect dbConn = new DbConnect();

        public string InsertCourse(Course course)
        {
            dbConn.OpenConnection();

            SqlCommand cmd = new SqlCommand("nsp_insertCourse @CourseName, @StartDate, @EndDate", dbConn.connection);

            //Insert Student Details
            cmd.Parameters.Add("@CourseName", SqlDbType.VarChar, 50).Value = course.CourseName;

            if (course.StartDate == null)
            {
                cmd.Parameters.Add("@StartDate", SqlDbType.VarChar, 50).Value = DBNull.Value;
            }
            else
            {
                cmd.Parameters.Add("@StartDate", SqlDbType.VarChar, 50).Value = course.StartDate;
            }

            if (course.EndDate == null)
            {
                cmd.Parameters.Add("@EndDate", SqlDbType.VarChar, 50).Value = DBNull.Value;
            }
            else
            {
                cmd.Parameters.Add("@EndDate", SqlDbType.VarChar, 50).Value = course.EndDate;
            }

            cmd.ExecuteNonQuery();

            string respMessage = course.CourseName + " Added Succesfully";
            return respMessage;
        }
    }
}
