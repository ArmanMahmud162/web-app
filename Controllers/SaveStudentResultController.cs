using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementApp.Manager;
using UniversityManagementApp.Models;

namespace UniversityManagementApp.Controllers
{
    public class SaveStudentResultController : Controller
    {
        public ActionResult Save()
        {
            SaveStudentResultManager manager = new SaveStudentResultManager();
            //SaveDepartmentManager Departmentmanager = new SaveDepartmentManager();

            //ViewBag.Departments = Departmentmanager.GetAll();
            // SaveCourseManager courseManager = new SaveCourseManager();


            ViewBag.RegNo = manager.GetRegNo();
            ViewBag.CourseName = manager.GetCourseName();
            ViewBag.GradeLetter = manager.GetAllGrade();

            return View();


        }
        [HttpPost]
        public ActionResult Save(StudentResult studentResult)
        {
            SaveStudentResultManager manager = new SaveStudentResultManager();
            string message = manager.Save(studentResult);
            ViewBag.Message = message;
            ViewBag.GradeLetter = manager.GetAllGrade();
            ViewBag.RegNo = manager.GetRegNo();
            ViewBag.CourseName = manager.GetCourseName();
           // ViewBag.GradeLetter = GetGradeLetter();
            return View();
        }
        //private List<GradeLetter> GetGradeLetter()
        //{
        //    List<GradeLetter> grades = new List<GradeLetter>()
        //    {
        //        new GradeLetter(){Id=1,Grade="A+"},
        //         new GradeLetter(){Id=2,Grade="A"},
        //         new GradeLetter(){Id=3,Grade="A-"},
        //         new GradeLetter(){Id=4,Grade="B+"},
        //         new GradeLetter(){Id=5,Grade="B"},
        //         new GradeLetter(){Id=6,Grade="B-"},
        //         new GradeLetter(){Id=7,Grade="C+"},
        //         new GradeLetter(){Id=8,Grade="C"},
        //         new GradeLetter(){Id=9,Grade="C-"},
        //         new GradeLetter(){Id=10,Grade="D+"},
        //         new GradeLetter(){Id=11,Grade="D"},
        //         new GradeLetter(){Id=12,Grade="D-"},
        //         new GradeLetter(){Id=13,Grade="F"},



        //    };
        //    return grades;

        //}
        public JsonResult GetStudentInfoByStudentId(int? RegStudentId)
        {
            SaveStudentResultManager manager = new SaveStudentResultManager();
            var student = manager.GetStudentInfoByStudentId(RegStudentId);
            return Json(student);
        }
        public JsonResult GetDepartmentByStudentId(int? RegStudentId)
        {
            SaveStudentResultManager manager = new SaveStudentResultManager();
            var department = manager.GetDepartmentByStudentId(RegStudentId);
            return Json(department);
        }

        public JsonResult GetEnrollCoursesByStudentId(int? RegStudentId)
        {

            SaveStudentResultManager manager = new SaveStudentResultManager();
            var course = manager.GetEnrollCoursesByStudentId(RegStudentId);
            return Json(course);
        }
	}
}