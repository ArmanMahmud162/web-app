using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityManagementApp.Models;

namespace UniversityManagementApp.Gateway
{
    public class DesignationGateway:BaseGateWay
    {
        public List<Designation> GetAll()
        {
            
            SqlCommand command = new SqlCommand
            {
                Connection = Connection,
                CommandText = "SELECT * FROM Designation"
            };
            Connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<Designation> designations = new List<Designation>();
            while (reader.Read())
            {
                Designation designation = new Designation
                {
                    Id = (int)reader["Id"],
                    Designationn = reader["Designation"].ToString()
                };
                designations.Add(designation);
            }
            reader.Close();
            Connection.Close();
            return designations;
        }
    }
}