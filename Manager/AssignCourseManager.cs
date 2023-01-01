using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementApp.Gateway;
using UniversityManagementApp.Models;

namespace UniversityManagementApp.Manager
{
    public class AssignCourseManager
    {
        private TeacherManager teacherManager;
        private AssignCourseGateway assignCourseGateway;

        public AssignCourseManager()
        {
            teacherManager = new TeacherManager();
            assignCourseGateway = new AssignCourseGateway();
        }
        public string Assign(AssignCourse assignCourse)
        {
            Teacher teacher = teacherManager.GetTeacherdetailsById(assignCourse.TeacherId);
            decimal remainingCredit = teacher.RemainingCredit;
            Course course = assignCourseGateway.GetCourseInfoByCourseId(assignCourse.CourseId);
            decimal courseCredit = course.Credit;
            remainingCredit = remainingCredit - courseCredit;
            teacher.RemainingCredit = remainingCredit;
            teacherManager.UpdateRemainingCredit(teacher);
            int rowAffected = assignCourseGateway.Assign(assignCourse);

            if (rowAffected > 0)
            {
                return "course Assigned";
            }
            return "course Assigned failed";
        }
        public List<Course> GetAllCoursesByDepartmentId(int departmrntId)
        {
            AssignCourseGateway gateway = new AssignCourseGateway();
            return gateway.GetAllCoursesByDepartmentId(departmrntId);

        }

        public Course GetCourseInfoByCourseId(int? courseId)
        {
            AssignCourseGateway gateway = new AssignCourseGateway();
            return gateway.GetCourseInfoByCourseId(courseId);
        }
    }
}
