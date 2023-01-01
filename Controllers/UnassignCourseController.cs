using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementApp.Manager;
using UniversityManagementApp.Models;

namespace UniversityManagementApp.Controllers
{
    public class UnassignCourseController : Controller
    {
        private  CourseManager courseManager=new CourseManager();

        //
        // GET: /UnassignCourse/
        public ActionResult Unassign()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Unassign(Course course)
        {
            if(courseManager.)

        }



	}
}