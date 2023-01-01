using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityManagementApp.Models;

namespace UniversityManagementApp.Gateway
{
    public class ViewCourseGateWay:BaseGateWay
    {
      
        public List<Course> GetCourseInfoByDepartmentId(int departmentId)
        {
            
            string query = "SELECT Course.Code,Course.Name,Semester.Semesterr,SaveTeacher.Name As Assigned_To FROM SaveCourse INNER JOIN Semester ON SaveCourse.SemesterId=Semester.Id Inner JOIN  SaveTeacher On SaveCourse.DepartmentId=SaveTeacher.DepartmentId AND SaveCourse.DepartmentId=" + departmentId;


            SqlCommand command = new SqlCommand(query, Connection);
            Connection.Open();

            List<Course> allCourseInfo = new List<Course>();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {

                string code = reader["Code"].ToString();
                string name = reader["Name"].ToString();
                string semester = reader["Semester"].ToString();
                string techerName = reader["Assigned_To"].ToString();

                Course saveCouse = new Course();
                saveCouse.Code = code;
                saveCouse.Name = name.ToString();
                saveCouse.Semester = semester.ToString();
                saveCouse.Assigned_To = techerName;
                allCourseInfo.Add(saveCouse);
            }
            reader.Close();
            Connection.Close();

            return allCourseInfo;
        }
        public List<Course> GetCourseInfo()
        {
            
            string query = "SELECT SaveCourse.Code,SaveCourse.Name,Semester.Semesterr,SaveTeacher.Name As Assigned_To FROM SaveCourse INNER JOIN Semester ON SaveCourse.SemesterId=Semester.Id Inner JOIN  SaveTeacher On SaveCourse.DepartmentId=SaveTeacher.DepartmentId ";


            SqlCommand command = new SqlCommand(query, Connection);
            Connection.Open();

            List<Course> allCourseInfo = new List<Course>();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {

                string code = reader["Code"].ToString();
                string name = reader["Name"].ToString();
               // string semester = reader["Semester"].ToString();
               // string techerName = reader["Assigned_To"].ToString();

                Course saveCouse = new Course();
                saveCouse.Code = code;
                saveCouse.Name = name.ToString();
              //  saveCouse.Semester = semester.ToString();
              //  saveCouse.Assigned_To = techerName;
                allCourseInfo.Add(saveCouse);
            }
            reader.Close();
            Connection.Close();

            return allCourseInfo;
        }
        public List<CourseStaticView> GetCourseStaticByDepartmentId(int? departmentId)
        {
           
            SqlCommand command = new SqlCommand
            {
                Connection = Connection,
                CommandText = "SELECT * From CourseStaticView WHERE DepartmentId = '" + departmentId + "'"

            };
            Connection.Open();
            List<CourseStaticView> courses = new List<CourseStaticView>();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                CourseStaticView course = new CourseStaticView();
                course.Id = (int)reader["Id"];
                course.Code = reader["Code"].ToString();
                course.Name = reader["Name"].ToString();
                course.DepartmentId = (int)reader["DepartmentId"];
                course.TeacherName = reader["TeacherName"].ToString();
                course.Semesterr = reader["Semesterr"].ToString();
                courses.Add(course);
            }
            reader.Close();
            Connection.Close();
            return courses;
        }

        public Department GetDepartmentCodeByDepartmentId(int? departmentId)
        {
           
            SqlCommand command = new SqlCommand
            {
                Connection = Connection,
                CommandText = "SELECT * From SaveDepartment WHERE Id = '" + departmentId + "'"

            };
            Connection.Open();
            Department department = new Department();
            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                department.Id = (int)reader["Id"];
                department.Code = reader["Code"].ToString();
                department.Name = reader["Name"].ToString();
            }
            reader.Close();
            Connection.Close();
            return department;
        }

    }
}