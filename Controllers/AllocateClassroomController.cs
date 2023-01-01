using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementApp.Manager;
using UniversityManagementApp.Models;

namespace UniversityManagementApp.Controllers
{
    public class AllocateClassroomController : Controller
    {
     
        ViewDepartmentManager managerr = new ViewDepartmentManager();
        DepartmentManager departmentManager = new DepartmentManager();
        AllocateClassManager allocateClassManager = new AllocateClassManager();
   
     
        TeacherManager teacherManager = new TeacherManager();

        public ActionResult Allocate()
        {
            // var teachers = teacherManager.GetAllTeachersByDepartmentId(1);
            //ViewBag.SaveDepartment = departmentManager.GetAll();
            //return View();

            ViewBag.SaveDepartment = managerr.GetAllDepartment();
           // ViewBag.Semester = semesterManager.GetAll();
            ViewBag.Room = allocateClassManager.GetAlldRooms();
            ViewBag.Days = allocateClassManager.GetAllDays();
            return View();
        }



        [HttpPost]
        public ActionResult Allocate(AllocateClass allocateClass)
        {
            AllocateClassManager allocateClassManagerr = new AllocateClassManager();
            DateTime fromTime = DateTime.Parse(allocateClass.Froms);
            DateTime toTime = DateTime.Parse(allocateClass.Tos);
            if (fromTime > toTime)
            {
                ViewBag.Message = "Invalid time range!";
            }
            else
            {

                string message = allocateClassManager.AllocateClass(allocateClass);
                ViewBag.Message = message;
            }
                 //AllocateClassManager allocateClassManager=new AllocateClassManager();
            ViewBag.SaveDepartment = managerr.GetAllDepartment();
            // ViewBag.Semester = semesterManager.GetAll();
            ViewBag.Room = allocateClassManager.GetAlldRooms();
            ViewBag.Days = allocateClassManager.GetAllDays();
            ViewBag.SaveDepartment = managerr.GetAllDepartment();
         
            // ViewBag.Semester = semesterManager.GetAll();
            return View();
        }

     

        public JsonResult GetAllCoursesByDepartmentId(int departmentId)
        {
            var courses = allocateClassManager.GetAllCoursesByDepartmentId(departmentId);
            return Json(courses);
           // return Json(courses,JsonRequestBehavior.AllowGet);
        }
	}
}