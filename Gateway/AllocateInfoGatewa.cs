using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementApp.Models;

namespace UniversityManagementApp.Gateway
{
    public class AllocateInfoGateway:BaseGateWay
    {
        public List<AllocateInfo> GetAllocateInfosByDepartmentId(int? departmentId)
        {
            string query = "SELECT * FROM AllocateInfoView WHERE DepartmentId = '" + departmentId + "' ORDER BY Code ASC";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            
            Reader = Command.ExecuteReader();
            List<AllocateInfo> allocateInfos = new List<AllocateInfo>();
            while(Reader.Read())
            {
                AllocateInfo allocateInfo = new AllocateInfo();
                allocateInfo.DepartmentId = (int)Reader["DepartmentId"];
                allocateInfo.Code = Reader["Code"].ToString();
                allocateInfo.Name = Reader["Name"].ToString();
                allocateInfo.RoomNumber = Reader["Rooms"].ToString();
                if (allocateInfo.RoomNumber != "Not Scheduled Yet")
                {
                    allocateInfo.RoomId = (int)Reader["RoomId"];
                    allocateInfo.DayId = (int)Reader["DayId"];
                    allocateInfo.Day = Reader["Days"].ToString();
                    allocateInfo.Froms = Reader["Froms"].ToString();
                    allocateInfo.Tos = Reader["Tos"].ToString();
                    allocateInfo.Action = Reader["Action"].ToString();
                }

                allocateInfos.Add(allocateInfo);
            }
            Reader.Close();
            Connection.Close();
            return allocateInfos;
        } 
    }
}