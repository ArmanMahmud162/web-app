using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementApp.Manager;
using UniversityManagementApp.Models;

namespace UniversityManagementApp.Controllers
{
    public class ViewDeparmentController : Controller
    {
        //
        // GET: /ViewDifferment/
        public ActionResult ViewDepartment()
        {
            ViewDepartmentManager manager = new ViewDepartmentManager();
            ViewBag.SaveDepartment = manager.GetAllDepartment();
            return View();
        }
        //[HttpPost]
        //public ActionResult ViewDepartment(Department department)
        //{
        //    ViewDepartmentManager manager=new ViewDepartmentManager();
        //    ViewBag.SaveDepartment = manager.GetAllDepartment();
        //    return View();

        //}
	}
}