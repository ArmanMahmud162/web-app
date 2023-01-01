using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementApp.Manager;
using UniversityManagementApp.Models;

namespace UniversityManagementApp.Controllers
{
    public class EnrollCourseController : Controller
    {
        EnrollCourseManager manager = new EnrollCourseManager();
        private DepartmentManager departmentManager;

        public EnrollCourseController()
        {
            departmentManager = new DepartmentManager();
        }

        [HttpGet]
        public ActionResult Enroll()
        {

            ViewBag.RegisterStudent = manager.GetRegisterStudents();
            ViewBag.SaveCourse = manager.GetSelectCourses();
            return View();
        }
        [HttpPost]
        public ActionResult Enroll(EnrollCourses enrollCourses)
        {

            string message = manager.Enroll(enrollCourses);
            ViewBag.Message = message;
            ViewBag.RegisterStudent = manager.GetRegisterStudents();
            ViewBag.SaveCourse = manager.GetSelectCourses();
            return View();
        }

        public JsonResult GetStudentInfo(int? RegNoId)
        {
            var regNoId = manager.GetStudentInfo(RegNoId);
            return Json(regNoId);
        }

        public JsonResult GetDepartmentByDepartmentId(int? RegNoId)
        {
            var regNoId = manager.GetStudentInfo(RegNoId);
            var department = manager.GetDepartmentByDepartmentId(regNoId.DepartmentId);
            return Json(department);
        }
	}
}