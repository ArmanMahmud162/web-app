using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityManagementApp.Models;

namespace UniversityManagementApp.Gateway
{
    public class DepartmentGateWay : BaseGateWay
    {
        public int Save(Department department)
        {
          
            string query =
                "INSERT INTO SaveDepartment (Code,Name) VALUES ('"+department.Code+"','" + department.Name + "')";
            SqlCommand command = new SqlCommand();
            command.CommandText = query;
            command.Connection = Connection;
            Connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            //connection.Close();
            command.Connection.Close();
            return rowAffected;
        }
        public bool IsCodeExist(string code)
        {


            string query = "SELECT * FROM SaveDepartment WHERE Code='" + code + "'";
            SqlCommand Command = new SqlCommand(query, Connection);
            Connection.Open();
            SqlDataReader Reader = Command.ExecuteReader();
            bool isCodeExist = Reader.HasRows;
            Connection.Close();
            return isCodeExist;
        }

        public bool IsNameExist(string name)
        {


            string query = "SELECT * FROM SaveDepartment WHERE Name='" + name + "'";
            SqlCommand Command = new SqlCommand(query, Connection);
            Connection.Open();
            SqlDataReader Reader = Command.ExecuteReader();
            bool isNameExist = Reader.HasRows;
            Connection.Close();
            return isNameExist;
        }
        
    }
}