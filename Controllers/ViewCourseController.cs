using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementApp.Manager;
using UniversityManagementApp.Models;

namespace UniversityManagementApp.Controllers
{
    public class ViewCourseController : Controller
    {
        ViewCourseManager courseManager = new ViewCourseManager();
        ViewDepartmentManager managerr=new ViewDepartmentManager();
        public ActionResult Show()
        {
            ViewCourseManager manager = new ViewCourseManager();

            ViewBag.Departments = managerr.GetAllDepartment();
            ViewBag.CourseInfo = courseManager.GetCourseInfo();
            return View();


        }
        [HttpPost]
        public List<Course> GetCourseInfo()
        {
            ViewCourseManager saveCourseManager = new ViewCourseManager();
            return saveCourseManager.GetCourseInfo();

        }
        //public JsonResult GetCourseInfoByDepartmentId(int departmentId)
        //{
        //    SaveCourseManager manager = new SaveCourseManager();
        //    var  viewCourse = manager.GetCourseInfoByDepartmentId(departmentId);
        //    var viewCourseList = viewCourse.ToList();
        //    return Json(viewCourseList);

        //}
        public JsonResult GetCourseBydeptId(int departmentId)
        {
            ViewCourseManager saveCourseManager = new ViewCourseManager();
            var course = saveCourseManager.GetCourseInfo();
            var acourseList = course.Where(a => a.Id == departmentId).ToList();
            return Json(acourseList, JsonRequestBehavior.AllowGet);
        }
        //public JsonResult ViewAssigendCourse(int Department_Id)
        //{
        //    var aViewCourses = aViewCourseManager.GetAllViewCourse(Department_Id);
        //    var aViewCoursesList = aViewCourses.ToList();
        //    return Json(aViewCoursesList, JsonRequestBehavior.AllowGet);
        //}

        public JsonResult GetCourseStaticByDepartmentId(int? departmentId)
        {
            ViewCourseManager manager = new ViewCourseManager();
            var course = manager.GetCourseStaticByDepartmentId(departmentId);
            return Json(course);
        }
	}
}