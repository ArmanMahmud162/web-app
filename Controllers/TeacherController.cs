using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementApp.Manager;
using UniversityManagementApp.Models;

namespace UniversityManagementApp.Controllers
{
    public class TeacherController : Controller
    {
        //
        // GET: /Teacher/
        ViewDepartmentManager managerr = new ViewDepartmentManager();
        DepartmentManager departmentManager = new DepartmentManager();
        DesignationManager designationManager = new DesignationManager();


        [HttpGet]
        public ActionResult Save()
        {
            ViewBag.SaveDepartment = managerr.GetAllDepartment();
            ViewBag.Designation = designationManager.GetAll();
            return View();
        }
        [HttpPost]
        public ActionResult Save(Teacher teacher)
        {
            TeacherManager manager = new TeacherManager();
            string message = manager.Save(teacher);
            ViewBag.Message = message;
            ViewBag.SaveDepartment = managerr.GetAllDepartment();
            ViewBag.Designation = designationManager.GetAll();
            return View();
        }
	}
}