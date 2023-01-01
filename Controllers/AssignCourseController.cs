using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementApp.Manager;
using UniversityManagementApp.Models;

namespace UniversityManagementApp.Controllers
{
    public class AssignCourseController : Controller
    {
        ViewDepartmentManager managerr = new ViewDepartmentManager();
      //  private DepartmentManager departmentManager = new DepartmentManager();
        DepartmentManager departmentManager = new DepartmentManager();
        TeacherManager teacherManager = new TeacherManager();
        AssignCourseManager assignCourseManager = new AssignCourseManager();
        public ActionResult Assign()
        {
            // var teachers = teacherManager.GetAllTeachersByDepartmentId(1);
            ViewBag.SaveDepartment = managerr.GetAllDepartment();
            return View();
        }



        [HttpPost]
        public ActionResult Assign(AssignCourse assigncourse)
        {
            string message = assignCourseManager.Assign(assigncourse);

            ViewBag.SaveDepartment = managerr.GetAllDepartment();
            ViewBag.Message = message;
            // ViewBag.Semester = semesterManager.GetAll();
            return View();
        }

        public JsonResult GetAllTeachersByDepartmentId(int departmentId)
        {
            var teachers = teacherManager.GetAllTeachersByDepartmentId(departmentId);
            return Json(teachers);
        }

        public JsonResult GetAllCoursesByDepartmentId(int departmentId)
        {
            var course = assignCourseManager.GetAllCoursesByDepartmentId(departmentId);
            return Json(course);
        }

        public ActionResult GetTeacherdetailsById(int? teacherId)
        {
            var teacher = teacherManager.GetTeacherdetailsById(teacherId);
            return Json(teacher);

        }

        public JsonResult GetCourseInfoByCourseId(int? courseId)
        {
            var course = assignCourseManager.GetCourseInfoByCourseId(courseId);
            return Json(course);
        }
	}
}