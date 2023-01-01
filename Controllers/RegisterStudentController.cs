using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementApp.Manager;
using UniversityManagementApp.Models;

namespace UniversityManagementApp.Controllers
{
    public class RegisterStudentController : Controller
    {
        ViewDepartmentManager DepaermentManager = new ViewDepartmentManager();
        ViewCourseManager manager=new ViewCourseManager();
        public ActionResult Register()
        {
            //SaveDepartmentManager manager = new SaveDepartmentManager();

            ViewBag.Departments = DepaermentManager.GetAllDepartment();
            return View();


            //return View();
        }
        [HttpPost]
        public ActionResult Register(RegisterStudent registerStudent)
        {
            string message;
            RegisterStudentManager registerStudentManager = new RegisterStudentManager();
            bool isEmailExist = registerStudentManager.IsEmailExits(registerStudent.Email);
            if (isEmailExist)
            {
                message = "Email Already Exist!";
                ViewBag.Message = message;
            }
            else
            {
                message = registerStudentManager.Register(registerStudent);
                ViewBag.Message = message;
                ViewBag.Student = registerStudentManager.GetStudent(registerStudent);
                SaveStudentResultManager studentManager = new SaveStudentResultManager();
                var department = studentManager.GetDepartmentByStudentId(registerStudent.DepartmentId);
                ViewBag.Department = department.Name;
            }
            ViewBag.Departments = DepaermentManager.GetAllDepartment();

            return View();
        }
	}
}