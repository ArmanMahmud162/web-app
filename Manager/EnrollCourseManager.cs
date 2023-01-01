using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementApp.Gateway;
using UniversityManagementApp.Models;

namespace UniversityManagementApp.Manager
{
    public class EnrollCourseManager
    {
        EnrollCourseGateway enrollCoursegateway = new EnrollCourseGateway();


        public string Enroll(EnrollCourses course)
        {

            int rowAffected = enrollCoursegateway.Enroll(course);
            if (rowAffected > 0)
            {
                return "Course enrolled";
            }
            return "Course enroll failed";
        }
        public List<RegisterStudent> GetRegisterStudents()
        {
            return enrollCoursegateway.GetRegisterStudents();
        }


        public List<Course> GetSelectCourses()
        {
            return enrollCoursegateway.GetSelectCourses();
        }

        public RegisterStudent GetStudentInfo(int? regNoId)
        {

            return enrollCoursegateway.GetStudentInfo(regNoId);
        }
        public Department GetDepartmentByDepartmentId(int? departmentId)
        {
            return enrollCoursegateway.GetDepartmentByDepartmentId(departmentId);
        }


    }
}