using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityManagementApp.Models;

namespace UniversityManagementApp.Gateway
{
    public class AssignCourseGateway:BaseGateWay
    {
        public int Assign(AssignCourse assignCourse)
        {

           
            string query = "INSERT INTO AssignCourse (DepartmentId,TeacherId,CourseId,Action) VALUES ('" + assignCourse.DepartmentId + "','" + assignCourse.TeacherId + "','" + assignCourse.CourseId + "', '" + assignCourse.Action + "')";
            SqlCommand command = new SqlCommand();
            command.CommandText = query;
            command.Connection = Connection;
            Connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;

        }
        public List<Course> GetAllCoursesByDepartmentId(int departmrntId)
        {
          
            SqlCommand command = new SqlCommand
            {
                Connection = Connection,
                CommandText = "SELECT * FROM SaveCourse where DepartmentId=" + departmrntId
            };
            Connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<Course> courses = new List<Course>();
            while (reader.Read())
            {
                Course course = new Course()
                {
                    Id = (int)reader["Id"],
                    // Code = reader["Code"].ToString(),
                    Name = reader["Name"].ToString(),
                    Code = reader["Code"].ToString()
                };
                courses.Add(course);

            }
            reader.Close();
            Connection.Close();
            return courses;
        }
        public Course GetCourseInfoByCourseId(int? courseId)
        {
          
            SqlCommand command = new SqlCommand
            {
                Connection = Connection,
                CommandText = "SELECT * FROM SaveCourse where Id = '" + courseId + "' "
            };
            //start

            //stop

            Connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            Course course = new Course();
            if (reader.Read())
            {
                course.Name = reader["Name"].ToString();
                course.Credit = (decimal)reader["Credit"];
                //course.Credit = reader["Credit"];
            }
            reader.Close();
            Connection.Close();
            return course;
        }
    }
}