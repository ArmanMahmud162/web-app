using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityManagementApp.Models;

namespace UniversityManagementApp.Gateway
{
    public class ViewDepartmentGateway:BaseGateWay
    {
        public List<Department> GetAllDepartment()
        {
            

           
            SqlCommand command = new SqlCommand
            {
                Connection = Connection,
                CommandText = "SELECT * FROM SaveDepartment"
            };
            Connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<Department> departments = new List<Department>();
            while (reader.Read())
            {
                Department department = new Department()
                {
                    Id = Convert.ToInt32(reader["Id"]),
                   
                    Code = reader["Code"].ToString(),
                    Name = reader["Name"].ToString()
                };
                departments.Add(department);
            }
            reader.Close();
            Connection.Close();
            return departments;

        }

        
    }
}