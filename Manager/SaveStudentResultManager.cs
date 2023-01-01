using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementApp.Gateway;
using UniversityManagementApp.Models;

namespace UniversityManagementApp.Manager
{
    public class SaveStudentResultManager
    {
        public List<Grade> GetAllGrade()
        {
            SaveStudentResultGateWay gateWay = new SaveStudentResultGateWay();
            return gateWay.GetAll();
        }
        public List<RegisterStudent> GetRegNo()
        {
            SaveStudentResultGateWay gateWay = new SaveStudentResultGateWay();
            return gateWay.GetRegNo();
        }
        public List<Course> GetCourseName()
        {
            SaveStudentResultGateWay gateWay = new SaveStudentResultGateWay();
            return gateWay.GetCourseName();

        }
        public string Save(StudentResult studentResult)
        {
            SaveStudentResultGateWay studentResultGateWay = new SaveStudentResultGateWay();
            int rowAffected = studentResultGateWay.Save(studentResult);
            if (rowAffected > 0)
            {
                return "Result Saved";
            }
            return "Not Saved";


        }
        public RegisterStudent GetStudentInfoByStudentId(int? studentId)
        {
            SaveStudentResultGateWay gateWay = new SaveStudentResultGateWay();
            return gateWay.GetStudentInfoByStudentId(studentId);
        }
        public Department GetDepartmentByStudentId(int? studentId)
        {
            SaveStudentResultGateWay gateWay = new SaveStudentResultGateWay();
            var student = gateWay.GetStudentInfoByStudentId(studentId);
            var department = gateWay.GetDepartmentByDepartmentId(student.DepartmentId);
            return department;
        }
        public List<EnrollCourseView> GetEnrollCoursesByStudentId(int? studentId)
        {

            SaveStudentResultGateWay gateWay = new SaveStudentResultGateWay();
            return gateWay.GetEnrollCoursesByStudentId(studentId);

        }
    }
}