using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementApp.Gateway;
using UniversityManagementApp.Models;

namespace UniversityManagementApp.Manager
{
    public class ViewResultManager
    {
        private ViewResultGateway gateway = new ViewResultGateway();

        public List<RegisterStudent> GetRegisterStudents()
        {
            return gateway.GetRegisterStudents();
        }

        public void Result(ResultView resultView)
        {
            RegisterStudent registerStudent = gateway.GetStudentInfoByRegisterStudentId(resultView.RegisterStudentId);
        }

        //int rowAffected = gateway.Index(resultView);
        //if (rowAffected > 0)
        //{
        //    return "Department saved";
        //}
        //return "Department save failed";





        public RegisterStudent GetStudentInfoByRegisterStudentId(int? registerStudentId)
        {
            ViewResultGateway gateway = new ViewResultGateway();
            return gateway.GetStudentInfoByRegisterStudentId(registerStudentId);
        }
        public Department GetDepartmentByDepartmentId(int? departmentId)
        {
            ViewResultGateway gateway = new ViewResultGateway();
            return gateway.GetDepartmentByDepartmentId(departmentId);
        }
        public List<ViewResults> GetResult(int? registerStudentId)
        {
            ViewResultGateway gateway = new ViewResultGateway();
            return gateway.GetResult(registerStudentId);
        }
    }
}