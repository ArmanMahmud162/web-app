using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityManagementApp.Models;

namespace UniversityManagementApp.Gateway
{
    public class CourseGateway:BaseGateWay
    {
        public int Save(Course course)
        {
           
            string query =
                "INSERT INTO SaveCourse (Code,Name,Credit,Description,DepartmentId,SemesterId) VALUES ('" + course.Code + "', '" + course.Name + "', '" + course.Credit + "','" + course.Description + "','" + course.DepartmentId + "','" + course.SemesterId + "')";
            SqlCommand command = new SqlCommand();
            command.CommandText = query;
            command.Connection = Connection;
            Connection.Open();
            int rowAffected = command.ExecuteNonQuery();

            command.Connection.Close();
            return rowAffected;
        }

        public bool IsCodeExist(string code)
        {


            string query = "SELECT * FROM SaveCourse WHERE Code='" + code + "'";
            SqlCommand Command = new SqlCommand(query, Connection);
            Connection.Open();
            SqlDataReader Reader = Command.ExecuteReader();
            bool isNameExist = Reader.HasRows;
            Connection.Close();
            return isNameExist;
        }

        public bool IsNameExist(string name)
        {


            string query = "SELECT * FROM SaveCourse WHERE Name='" + name + "'";
            SqlCommand Command = new SqlCommand(query, Connection);
            Connection.Open();
            SqlDataReader Reader = Command.ExecuteReader();
            bool isNameExist = Reader.HasRows;
            Connection.Close();
            return isNameExist;
        }
    }
}