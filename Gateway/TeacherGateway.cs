using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityManagementApp.Models;

namespace UniversityManagementApp.Gateway
{
    public class TeacherGateway:BaseGateWay
    {
        public int Save(Teacher teacher)
        {
           
            string query =
                "INSERT INTO SaveTeacher (Name,Address,Email,ContactNo,DepartmentId,DesignationId,CreditToBetaken,RemainingCredit) VALUES ( '" + teacher.Name + "', '" + teacher.Address + "','" + teacher.Email + "','" + teacher.ContactNo + "','" + teacher.DepartmentId + "','" + teacher.DesignationId + "','" + teacher.CreditToBetaken + "','" + teacher.CreditToBetaken + "')";
            SqlCommand command = new SqlCommand();
            command.CommandText = query;
            command.Connection = Connection;
            Connection.Open();
            int rowAffected = command.ExecuteNonQuery();

            command.Connection.Close();
            return rowAffected;
        }

        public bool IsEmailExist(string email)
        {


            string query = "SELECT * FROM SaveTeacher WHERE Email='" + email + "'";
            SqlCommand Command = new SqlCommand(query, Connection);
            Connection.Open();
            SqlDataReader Reader = Command.ExecuteReader();
            bool isEmailExist = Reader.HasRows;
            Connection.Close();
            return isEmailExist;
        }
        public List<Teacher> GetAllTeachersByDepartmentId(int departmrntId)
        {
           
            SqlCommand command = new SqlCommand
            {
                Connection = Connection,
                CommandText = "SELECT * FROM SaveTeacher where DepartmentId=" + departmrntId
            };
            Connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<Teacher> teachers = new List<Teacher>();
            while (reader.Read())
            {
                Teacher teacher = new Teacher()
                {
                    Id = (int)reader["Id"],
                    // Code = reader["Code"].ToString(),
                    Name = reader["Name"].ToString()
                };
                teachers.Add(teacher);
            }
            reader.Close();
            Connection.Close();
            return teachers;
        }


        public Teacher GetTeacherdetailsById(int? teacherId)
        {
         
            SqlCommand command = new SqlCommand
            {
                Connection = Connection,
                CommandText = "SELECT * FROM SaveTeacher WHERE Id='" + teacherId + "' "
            };
            Connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            Teacher teacher = new Teacher();
            if (reader.Read())
            {
                teacher.Id = (int)reader["Id"];
                teacher.CreditToBetaken = (decimal)reader["CreditToBetaken"];
                teacher.RemainingCredit = (decimal)reader["RemainingCredit"];
            }
            reader.Close();
            Connection.Close();
            return teacher;
        }

        public int UpdateRemainingCredit(Teacher teacher)
        {
            
            string query =
                "UPDATE SaveTeacher SET RemainingCredit = '" + teacher.RemainingCredit + "' WHERE Id = '" + teacher.Id + "' ";
            SqlCommand command = new SqlCommand();
            command.CommandText = query;
            command.Connection = Connection;
            Connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            command.Connection.Close();
            return rowAffected;
        }
       
    }
}