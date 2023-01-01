using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementApp.Gateway;
using UniversityManagementApp.Models;

namespace UniversityManagementApp.Manager
{
    public class RegisterStudentManager
    {
        public string Register(RegisterStudent registerStudent)
        {
         RegisterStudentGateWay registerStudentGateWay = new RegisterStudentGateWay();
         ViewCourseManager departmentManager = new ViewCourseManager();
            Department department = departmentManager.GetDepartmentCodeByDepartmentId(registerStudent.DepartmentId);
            string code = department.Code;
            string year = registerStudent.Date.Substring(6, 4);
            string pattern = code + "-" + year + "-";
            int total = registerStudentGateWay.TotalStudent(pattern);
            if (total >= 0 && total < 10)
            {
                registerStudent.RegNo = pattern + "00" + (total + 1);
            }
            else if (total >= 10 && total < 100)
            {
                registerStudent.RegNo = pattern + "0" + (total + 1);
            }
            else
            {
                registerStudent.RegNo = pattern + (total + 1);
            }
            GetStudent(registerStudent);
            int rowAffected = registerStudentGateWay.Register(registerStudent);
            if (rowAffected > 0)
            {
                return "Registration completed";
            }
            return "Not Registration completed ";

        }

        public RegisterStudent GetStudent(RegisterStudent registerStudent)
        {
            return registerStudent;
        }
        public bool IsEmailExits(string email)
        {
              RegisterStudentGateWay registerStudentGateWay = new RegisterStudentGateWay();
              return registerStudentGateWay.IsEmailExits(email);
        }
    }
}