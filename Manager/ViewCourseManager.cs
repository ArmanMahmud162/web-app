using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementApp.Gateway;
using UniversityManagementApp.Models;

namespace UniversityManagementApp.Manager
{
    public class ViewCourseManager
    {
        public List<CourseStaticView> GetCourseStaticByDepartmentId(int? departmentId)
        {
            ViewCourseGateWay gateWay = new ViewCourseGateWay();
            return gateWay.GetCourseStaticByDepartmentId(departmentId);
        }
        public Department GetDepartmentCodeByDepartmentId(int? departmentId)
        {
            ViewCourseGateWay gateWay = new ViewCourseGateWay();
            return gateWay.GetDepartmentCodeByDepartmentId(departmentId);
        }
        public List<Course> GetCourseInfoByDepartmentId(int departmentId)
        {
            ViewCourseGateWay saveCourseGateWay = new ViewCourseGateWay();
            return saveCourseGateWay.GetCourseInfoByDepartmentId(departmentId);

        }


        public List<Course> GetCourseInfo()
        {
            ViewCourseGateWay saveCourseGateWay = new ViewCourseGateWay();
            return saveCourseGateWay.GetCourseInfo();
        }
    }
}