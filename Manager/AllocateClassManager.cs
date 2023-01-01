using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementApp.Gateway;
using UniversityManagementApp.Models;

namespace UniversityManagementApp.Manager
{
    public class AllocateClassManager
    {
        public string AllocateClass(AllocateClass allocateClass)
        {

            AllocateClassroomGateway allocateClassroomGateway = new AllocateClassroomGateway();
            var allocateClasses = allocateClassroomGateway.GetClassSchedule(allocateClass);
            bool free = true;
            foreach (var value in allocateClasses)
            {
                DateTime DbFromTime = DateTime.Parse(value.Froms);
                DateTime DbTotime = DateTime.Parse(value.Tos);
                DateTime fromTime = DateTime.Parse(allocateClass.Froms);
                DateTime toTime = DateTime.Parse(allocateClass.Tos);

                if ((fromTime >= DbFromTime && toTime <= DbTotime) || (fromTime < DbFromTime && toTime > DbFromTime) || (fromTime >= DbFromTime && fromTime <= DbTotime) && toTime >= DbTotime)
                {
                    free = false;
                }


            }
            if (free)
            {
                int rowAffected = allocateClassroomGateway.Allocate(allocateClass);

                if (rowAffected > 0)
                {
                    return "Course Allocated";
                }
                return "course Assigned failed";
            }
            return "Classroom not available in selected time!";
        }
        public List<Course> GetAllCoursesByDepartmentId(int departmrntId)
        {
            AllocateClassroomGateway gateway = new AllocateClassroomGateway();
            return gateway.GetAllCoursesByDepartmentId(departmrntId);

        }

        public List<Day> GetAllDays()
        {
            AllocateClassroomGateway gateway = new AllocateClassroomGateway();
            return gateway.GetAllDays();

        }

        public List<Room> GetAlldRooms()
        {
            AllocateClassroomGateway gateway = new AllocateClassroomGateway();
            return gateway.GetAllRooms();
        }
        //public List<AllocateClass> GetClassSchedule(AllocateClass allocateClass)
        //{
        //     AllocateClassroomGateway gateway = new AllocateClassroomGateway();
        //    return gateway.GetClassSchedule(allocateClass);
        //}

    }
}