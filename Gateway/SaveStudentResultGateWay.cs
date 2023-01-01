using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityManagementApp.Models;

namespace UniversityManagementApp.Gateway
{
    public class SaveStudentResultGateWay:BaseGateWay
    {
        public List<Grade> GetAll()
        {
            
           
            SqlCommand command = new SqlCommand
            {
                Connection = Connection,
                CommandText = "SELECT * FROM Grade"
            };
            Connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<Grade> grades = new List<Grade>();
            while (reader.Read())
            {
                Grade grade = new Grade()
                {
                    Id = Convert.ToInt32(reader["Id"]),

                   
                    Grades = reader["Grade"].ToString()
                };
                grades.Add(grade);
            }
            reader.Close();
            Connection.Close();
            return grades;

        }
        public List<RegisterStudent> GetRegNo()
        {
            
            SqlCommand command = new SqlCommand
            {
                Connection = Connection,
                CommandText = "Select * from RegisterStudent"

            };
            Connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<RegisterStudent> registerStudents = new List<RegisterStudent>();
            while (reader.Read())
            {
                RegisterStudent registerStudent = new RegisterStudent
                {
                    Id = (int)reader["Id"],
                    RegNo = reader["RegNo"].ToString()
                };
                registerStudents.Add(registerStudent);
            }
            reader.Close();
            Connection.Close();
            return registerStudents;


        }
        public List<RegisterStudent> GetStudentIn()
        {
            
            SqlCommand command = new SqlCommand
            {
                Connection = Connection,
                CommandText = "Select * from RegisterStudent"

            };
            Connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<RegisterStudent> registerStudents = new List<RegisterStudent>();
            while (reader.Read())
            {
                RegisterStudent registerStudent = new RegisterStudent
                {
                    Id = (int)reader["Id"],
                    RegNo = reader["RegNo"].ToString()
                };
                registerStudents.Add(registerStudent);
            }
            reader.Close();
            Connection.Close();
            return registerStudents;


        }
        public List<Course> GetCourseName()
        {
          
            SqlCommand command = new SqlCommand
            {
                Connection = Connection,
                CommandText = "SELECT * From SaveCourse"

            };
            Connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<Course> courses = new List<Course>();
            while (reader.Read())
            {
                Course course = new Course
                {
                    Id = (int)reader["Id"],
                    Name = reader["Name"].ToString()
                };
                courses.Add(course);
            }
            reader.Close();
            Connection.Close();
            return courses;


        }
        public int Save(StudentResult studentResult)
        {
            
            string qurey = "INSERT INTO StudentResult (RegStudentId,CourseId,GradeId) VALUES ('" + studentResult.RegStudentId + "','" + studentResult.CourseId + "'," + studentResult.GradeId + ")";
            SqlCommand command = new SqlCommand();
            command.CommandText = qurey;
            command.Connection = Connection;
            Connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;



        }

        public RegisterStudent GetStudentInfoByStudentId(int? studentId)
        {
           
            SqlCommand command = new SqlCommand
            {
                Connection = Connection,
                CommandText = "SELECT * From RegisterStudent WHERE Id= '" + studentId + "'"
            };
            Connection.Open();
            RegisterStudent student = new RegisterStudent();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                student.Name = reader["Name"].ToString();
                student.Email = reader["Email"].ToString();
                student.DepartmentId = (int)reader["DepartmentId"];
            }
            reader.Close();
            Connection.Close();
            return student;
        }

        public Department GetDepartmentByDepartmentId(int? departmentId)
        {
            
            SqlCommand command = new SqlCommand
            {
                Connection = Connection,
                CommandText = "SELECT * From SaveDepartment WHERE Id= '" + departmentId + "'"
            };
            Connection.Open();
            Department department = new Department();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                department.Name = reader["Name"].ToString();
                department.Code = reader["Code"].ToString();
            }
            reader.Close();
            Connection.Close();
            return department;
        }

        public List<EnrollCourseView> GetEnrollCoursesByStudentId(int? studentId)
        {
           
            SqlCommand command = new SqlCommand
            {
                Connection = Connection,
                CommandText = "SELECT * From EnrollCourseView WHERE RegStudentId = '" + studentId + "'"

            };
            Connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<EnrollCourseView> enrollCourses = new List<EnrollCourseView>();
            while (reader.Read())
            {
                EnrollCourseView enrollCourse = new EnrollCourseView
                {
                    //Id = (int)reader["Id"],
                    StudentId = (int)reader["RegStudentId"],
                    CourseId = (int)reader["CourseId"],
                    Name = reader["CourseTitle"].ToString(),
                    Code = reader["CourseCode"].ToString()
                };
                enrollCourses.Add(enrollCourse);
            }
            reader.Close();
            Connection.Close();
            return enrollCourses;


        }

    }
}