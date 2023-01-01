using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementApp.Manager;
using UniversityManagementApp.Models;

namespace UniversityManagementApp.Controllers
{
    public class CourseController : Controller
    {
        //
        // GET: /Course/
      
        ViewDepartmentManager managerr=new ViewDepartmentManager();
        DepartmentManager departmentManager = new DepartmentManager();
        SemesterManager semesterManager = new SemesterManager();


        [HttpGet]
        public ActionResult Save()
        {
            ViewBag.SaveDepartment = managerr.GetAllDepartment();
            ViewBag.Semester = semesterManager.GetAll();
            return View();
        }
        [HttpPost]
        public ActionResult Save(Course course)
        {
            //ViewDepartmentManager managerr = new ViewDepartmentManager();
            CourseManager manager = new CourseManager();
            string message = manager.Save(course);
            ViewBag.Message = message;
            ViewBag.SaveDepartment = managerr.GetAllDepartment();
            ViewBag.Semester = semesterManager.GetAll();
            return View();
        }

	}
}