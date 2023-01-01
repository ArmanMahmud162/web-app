using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityManagementApp.Models;

namespace UniversityManagementApp.Gateway
{
    public class ViewResultGateway:BaseGateWay
    {
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
        public RegisterStudent GetStudentInfoByRegisterStudentId(int? registerStudentId)
        {
           
            SqlCommand command = new SqlCommand
            {
                Connection = Connection,
                CommandText = "SELECT * FROM RegisterStudent where Id = '" + registerStudentId + "' "
            };
            Connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            RegisterStudent registerStudent = new RegisterStudent();
            Department department = new Department();
            if (reader.Read())
            {
                // registerStudent.Id = (int)reader["Id"];
                registerStudent.Name = reader["Name"].ToString();
                registerStudent.Email = reader["Email"].ToString();
                department.Name = reader["Name"].ToString();
                registerStudent.DepartmentId = (int)reader["DepartmentId"];


            }
            reader.Close();
            Connection.Close();
            return registerStudent;
        }
        public List<ViewResults> GetResult(int? registerStudentId)
        {
           
            SqlCommand command = new SqlCommand
            {
                Connection = Connection,
                CommandText = "SELECT * FROM StudentResultView where Id = '" + registerStudentId + "' "
            };
            Connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            //RegisterStudent registerStudent = new RegisterStudent();
            //Department department = new Department();
            List<ViewResults> viewResults = new List<ViewResults>();

            while (reader.Read())
            {
                ViewResults viewResult = new ViewResults();
                // registerStudent.Id = (int)reader["Id"];
                viewResult.Name = reader["Name"].ToString();
                viewResult.Code = reader["Code"].ToString();
                viewResult.Grade = reader["Grade"].ToString();
                //registerStudent.DepartmentId = (int)reader["DepartmentId"];
                viewResults.Add(viewResult);

            }
            reader.Close();
            Connection.Close();
            return viewResults;
        }
        public Department GetDepartmentByDepartmentId(int? departmentId)
        {
           
            SqlCommand command = new SqlCommand
            {
                Connection = Connection,
                CommandText = "SELECT * FROM SaveDepartment where Id = '" + departmentId + "' "
            };
            Connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            //RegisterStudent registerStudent = new RegisterStudent();
            Department department = new Department();
            if (reader.Read())
            {
                // registerStudent.Id = (int)reader["Id"];
                // registerStudent.Name = reader["Name"].ToString();
                // registerStudent.Email = reader["Email"].ToString();
                department.Name = reader["Name"].ToString();
                //registerStudent.DepartmentId = (int)reader["DepartmentId"];


            }
            reader.Close();
            Connection.Close();
            return department;
        }
    }
}