using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityManagementApp.Models;

namespace UniversityManagementApp.Gateway
{
    public class EnrollCourseGateway : BaseGateWay
    {
        public int Enroll(EnrollCourses enrollCourse)
        {


            string query = "INSERT INTO EnrollCourse (RegStudentId,courseId,Date) VALUES ('" + enrollCourse.RegStudentId +
                           "','" + enrollCourse.CourseId + "','" + enrollCourse.Date + "')";
            SqlCommand command = new SqlCommand();
            command.CommandText = query;
            command.Connection = Connection;
            Connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }

        public List<RegisterStudent> GetRegisterStudents()
        {


            SqlCommand command = new SqlCommand
            {
                Connection = Connection,
                CommandText = "Select * from RegisterStudent"
            };
            Connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<RegisterStudent> registerstudents = new List<RegisterStudent>();
            while (reader.Read())
            {
                RegisterStudent registerStudent = new RegisterStudent()
                {
                    Id = (int)reader["Id"],
                    RegNo = reader["RegNo"].ToString()
                };
                registerstudents.Add(registerStudent);
            }
            reader.Close();
            Connection.Close();
            return registerstudents;
        }



        public List<Course> GetSelectCourses()
        {


            SqlCommand command = new SqlCommand
            {
                Connection = Connection,
                CommandText = "Select * from SaveCourse"
            };
            Connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<Course> selectCourses = new List<Course>();
            while (reader.Read())
            {
                Course selectCourse = new Course()
                {
                    Id = (int)reader["Id"],
                    Name = reader["Name"].ToString()
                };
                selectCourses.Add(selectCourse);
            }
            reader.Close();
            Connection.Close();
            return selectCourses;
        }


        public RegisterStudent GetStudentInfo(int? regNoId)
        {

            SqlCommand command = new SqlCommand
            {
                Connection = Connection,
                CommandText = "SELECT * FROM RegisterStudent where Id = '" + regNoId + "' "
            };
            Connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            RegisterStudent registerStudent = new RegisterStudent();
            if (reader.Read())
            {
                registerStudent.Name = reader["Name"].ToString();
                registerStudent.Email = reader["Email"].ToString();
                registerStudent.DepartmentId = (int)reader["DepartmentId"];
            }
            reader.Close();
            Connection.Close();
            return registerStudent;
        }
        public Department GetDepartmentByDepartmentId(int? departmentId)
        {

            SqlCommand command = new SqlCommand
            {
                Connection = Connection,
                CommandText = "SELECT * FROM SaveDepartment WHERE Id = '" + departmentId + "'"
            };
            Connection.Open();
            Department department = new Department();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                department.Id = (int)reader["Id"];
                department.Name = reader["Name"].ToString();
            }
            reader.Close();
            Connection.Close();
            return department;
        }

    }
}