using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementApp.Manager;

namespace UniversityManagementApp.Controllers
{
    public class ViewResultController : Controller
    {
        ViewResultManager manager = new ViewResultManager();
        [HttpGet]
        public ActionResult Index()
        {

            ViewBag.RegisterStudent = manager.GetRegisterStudents();
            // ViewBag.result = manager.GetResult(ResultView);


            return View();
        }

        public JsonResult GetStudentInfoByRegisterStudentId(int? RegisterStudentId)
        {

            var registerStudent = manager.GetStudentInfoByRegisterStudentId(RegisterStudentId);
            //ViewResultManager managerr = new ViewResultManager();


            return Json(registerStudent);
        }
        public JsonResult GetDepartmentByDepartmentId(int? RegisterStudentId)
        {
            var registerStudent = manager.GetStudentInfoByRegisterStudentId(RegisterStudentId);
            var department = manager.GetDepartmentByDepartmentId(registerStudent.DepartmentId);
            return Json(department);
        }
        public JsonResult GetResult(int? RegisterStudentId)
        {
            var registerStudent = manager.GetStudentInfoByRegisterStudentId(RegisterStudentId);
            var department = manager.GetDepartmentByDepartmentId(registerStudent.DepartmentId);
            return Json(department);
        }
        public JsonResult GetResults(int? RegisterStudentId)
        {
            var result = manager.GetResult(RegisterStudentId);

            return Json(result);
        }


        [HttpPost]

        public ActionResult Index(int resultView)
        {
            ViewResultManager manager = new ViewResultManager();
            // ViewBag.result = manager.GetResult();
            return View();

        }

	}
}