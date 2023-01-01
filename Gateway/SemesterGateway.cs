using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityManagementApp.Models;

namespace UniversityManagementApp.Gateway
{
    public class SemesterGateway:BaseGateWay
    {
        public List<Semester> GetAll()
        {
           
            SqlCommand command = new SqlCommand
            {
                Connection = Connection,
                CommandText = "SELECT * FROM Semester"
            };
            Connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<Semester> semesters = new List<Semester>();
            while (reader.Read())
            {
                Semester semester = new Semester
                {
                    Id = (int)reader["Id"],
                    Semesterr = reader["Semesterr"].ToString()
                };
                semesters.Add(semester);
            }
            reader.Close();
            Connection.Close();
            return semesters;
        }
    }
}