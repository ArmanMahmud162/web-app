using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityManagementApp.Models;

namespace UniversityManagementApp.Gateway
{

    
    public class AllocateClassroomGateway:BaseGateWay
    {
        public int Allocate(AllocateClass allocateClass)
        {
            
            string query =
                "INSERT INTO AllocateClass (DepartmentId,CourseId,RoomId,DayId,Froms,Tos,Action) VALUES ('" + allocateClass.DepartmentId + "', '" + allocateClass.CourseId + "', '" + allocateClass.RoomId + "','" + allocateClass.DayId + "', '" + allocateClass.Froms + "', '" + allocateClass.Tos + "','" + allocateClass.Action + "')";
            SqlCommand command = new SqlCommand();
            command.CommandText = query;
            command.Connection = Connection;
            Connection.Open();
            int rowAffected = command.ExecuteNonQuery();


            command.Connection.Close();
            return rowAffected;
        }


        public List<Course> GetAllCoursesByDepartmentId(int departmrntId)
        {
           
            SqlCommand command = new SqlCommand
            {
                Connection = Connection,
                CommandText = "SELECT * FROM SaveCourse WHERE DepartmentId=" + departmrntId
            };
            Connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<Course> courses = new List<Course>();
            while (reader.Read())
            {
                Course course = new Course()
                {
                    Id = (int)reader["Id"],
                    // Code = reader["Code"].ToString(),
                    Name = reader["Name"].ToString()
                };
                courses.Add(course);
            }
            reader.Close();
            Connection.Close();
            return courses;
        }




       


        public List<Room> GetAllRooms()
        {
           
            SqlCommand command = new SqlCommand
            {
                Connection = Connection,
                CommandText = "SELECT * FROM Room"
            };
            Connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<Room> rooms = new List<Room>();
            while (reader.Read())
            {
                Room room = new Room()
                {
                    Id = (int)reader["Id"],
                    // Code = reader["Code"].ToString(),
                    Rooms = reader["Rooms"].ToString()
                };
                rooms.Add(room);
            }
            reader.Close();
            Connection.Close();
            return rooms;
        }


        public List<Day> GetAllDays()
        {
           
            SqlCommand command = new SqlCommand
            {
                Connection = Connection,
                CommandText = "SELECT * FROM Day"
            };
            Connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<Day> days = new List<Day>();
            while (reader.Read())
            {
                Day day = new Day()
                {
                    Id = (int)reader["Id"],
                    // Code = reader["Code"].ToString(),
                    Days = reader["Days"].ToString()
                };
                days.Add(day);
            }
            reader.Close();
            Connection.Close();
            return days;
        }

        public List<AllocateClass> GetClassSchedule(AllocateClass allocateClass)
        {
           
            SqlCommand command = new SqlCommand
            {
                Connection = Connection,
                CommandText = "SELECT * FROM AllocateClass WHERE RoomId ='"+allocateClass.RoomId+"' AND DayId ='"+allocateClass.DayId+"' "
            };
            Connection.Open();
            List<AllocateClass> allocateClasses = new List<AllocateClass>();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                AllocateClass allocate = new AllocateClass();
                //allocate.Id = (int) reader["Id"];
                //allocate.DepartmentId = (int) reader["DepartmentId"];
                //allocate.CourseId = (int)reader["CourseId"];
                //allocate.RoomId = (int)reader["RoomId"];
                //allocate.DayId = (int)reader["DayId"];
                allocate.Froms = reader["Froms"].ToString();
                allocate.Tos = reader["Tos"].ToString();
                allocateClasses.Add(allocate);
            }
            reader.Close();
            Connection.Close();
            return allocateClasses;
        }
    }
}