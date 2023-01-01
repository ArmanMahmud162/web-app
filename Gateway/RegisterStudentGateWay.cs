using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityManagementApp.Models;

namespace UniversityManagementApp.Gateway
{
    public class RegisterStudentGateWay:BaseGateWay
    {
        public int Register(RegisterStudent registerStudent)
        {
            
            string qurey = "INSERT INTO RegisterStudent (Name,Email,ContactNo,Date,Address,DepartmentId,RegNo) VALUES ('" + registerStudent.Name + "','" + registerStudent.Email + "','" + registerStudent.ContactNo + "','" + registerStudent.Date + "','" + registerStudent.Address + "','" + registerStudent.DepartmentId + "','" + registerStudent.RegNo + "')";
            SqlCommand command = new SqlCommand();
            command.CommandText = qurey;
            command.Connection = Connection;
            Connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }
        public bool IsEmailExits(string email)
        {
            
            string query = "SELECT * FROM RegisterStudent WHERE Email='" + email + "'";
            SqlCommand command = new SqlCommand();
            command.CommandText = query;
            command.Connection = Connection;
            Connection.Open();
            SqlDataReader Reader = command.ExecuteReader();
            bool isEmailExits = Reader.HasRows;
            Connection.Close();
            return isEmailExits;
        }

        public int TotalStudent(string pattern)
        {
            
            string query = "SELECT Count(RegNo) AS TotalStudent FROM RegisterStudent WHERE RegNo Like '" + pattern + "%'";
            SqlCommand command = new SqlCommand();
            command.CommandText = query;
            command.Connection = Connection;
            Connection.Open();
            int total = 0;
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                total = (int)reader["TotalStudent"];
            }
            reader.Close();
            Connection.Close();
            return total;
        }

    }
}