using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementApp.Gateway;
using UniversityManagementApp.Models;

namespace UniversityManagementApp.Manager
{
    public class AllocateInfoManager
    {
        private AllocateInfoGateway allocateInfoGateway;

        public AllocateInfoManager()
        {
            allocateInfoGateway = new AllocateInfoGateway();
        }

        public List<AllocateInfo> GetAllocateInfosByDepartmentId(int? departmentId)
        {
            return allocateInfoGateway.GetAllocateInfosByDepartmentId(departmentId);
        }

        public List<AllocateScheduleInfo> GetAllocateInfos(int? departmentId)
        {
            var allocate = allocateInfoGateway.GetAllocateInfosByDepartmentId(departmentId);
            string code = "";
            string schedule = "";
            List<AllocateScheduleInfo> allocateScheduleInfos = new List<AllocateScheduleInfo>();
            int count = -1;
            foreach (var value in allocate)
            {
                AllocateScheduleInfo allocateScheduleInfo = new AllocateScheduleInfo();
                allocateScheduleInfo.Code = value.Code;
                allocateScheduleInfo.Name = value.Name;
                if (value.RoomNumber == "Not Scheduled Yet")
                {
                    schedule = value.RoomNumber;
                    allocateScheduleInfo.Schedule = schedule;
                    allocateScheduleInfos.Add(allocateScheduleInfo);
                    count++;
                }
                else if (code == allocateScheduleInfo.Code)
                {
                    schedule = schedule + " R. No: " + value.RoomNumber + ", " + value.Day + ", " +
                                                    value.Froms + " - " + value.Tos;
                    allocateScheduleInfo.Schedule = schedule;
                    allocateScheduleInfos.Insert(count, allocateScheduleInfo);
                }
                else
                {
                    schedule = "R. No: " + value.RoomNumber + ", " + value.Day + ", " +
                                                    value.Froms + " - " + value.Tos;
                    allocateScheduleInfo.Schedule = schedule;
                    allocateScheduleInfos.Add(allocateScheduleInfo);
                    code = value.Code;
                    count++;
                }
            }
            return allocateScheduleInfos;
        } 
    }
}