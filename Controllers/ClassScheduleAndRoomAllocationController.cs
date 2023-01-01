using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementApp.Manager;

namespace UniversityManagementApp.Controllers
{
    public class ClassScheduleAndRoomAllocationController : Controller
    {
        ViewDepartmentManager managerr = new ViewDepartmentManager();
        private DepartmentManager departmentManager;
        private AllocateInfoManager allocateInfoManager;

        public ClassScheduleAndRoomAllocationController()
        {
            departmentManager = new DepartmentManager();
            allocateInfoManager = new AllocateInfoManager();
        }

        public ActionResult Show()
        {
            ViewBag.Departments = managerr.GetAllDepartment();
            return View();
        }
        public JsonResult GetAllocateInfos(int? departmentId)
        {
            var allocateInfo = allocateInfoManager.GetAllocateInfos(departmentId);
            return Json(allocateInfo);
        } 
	}
}