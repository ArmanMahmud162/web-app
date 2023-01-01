using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementApp.Gateway;
using UniversityManagementApp.Models;

namespace UniversityManagementApp.Manager
{
    public class CourseManager
    {
        public string Save(Course course)
        {
            CourseGateway gateway = new CourseGateway();
            bool isCodeExit = gateway.IsCodeExist(course.Code);
            if (isCodeExit)
            {
                return "Sorry,Code already exist";
            }
            bool isNameExit = gateway.IsNameExist(course.Name);
            if (isNameExit)
            {
                return "Sorry,Name already exist";
            }
            int rowAffected = gateway.Save(course);
            if (rowAffected > 0)
            {
                return "Course saved";
            }
            return "Course save failed";
        }
    }
}