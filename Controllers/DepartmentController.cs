using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementApp.Manager;
using UniversityManagementApp.Models;

namespace UniversityManagementApp.Controllers
{
    public class DepartmentController : Controller
    {
        [HttpGet]
        public ActionResult Save()
        {

            return View();
        }


        [HttpPost]
        public ActionResult Save(Department department)
        {
            DepartmentManager manager = new DepartmentManager();
            string message = manager.Save(department);
            ViewBag.Message = message;
            return View();
        }
	}
}