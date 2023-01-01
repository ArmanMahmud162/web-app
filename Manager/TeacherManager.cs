using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementApp.Gateway;
using UniversityManagementApp.Models;

namespace UniversityManagementApp.Manager
{
    public class TeacherManager
    {
        public string Save(Teacher teacher)
        {
            TeacherGateway gateway = new TeacherGateway();
            bool isCodeExit = gateway.IsEmailExist(teacher.Email);
            if (isCodeExit)
            {
                return "Sorry,Email already exist";
            }
            int rowAffected = gateway.Save(teacher);
            if (rowAffected > 0)
            {
                return "Teacher saved";
            }
            return "Teacher save failed";
        }
        public List<Teacher> GetAllTeachersByDepartmentId(int departmrntId)
        {
            TeacherGateway gateway = new TeacherGateway();
            return gateway.GetAllTeachersByDepartmentId(departmrntId);

        }
        public Teacher GetTeacherdetailsById(int? teacherId)
        {
            TeacherGateway gateway = new TeacherGateway();
            return gateway.GetTeacherdetailsById(teacherId);

        }
        public int UpdateRemainingCredit(Teacher teacher)
        {
            TeacherGateway gateway = new TeacherGateway();
            return gateway.UpdateRemainingCredit(teacher);
        }

        //public List<Teacher> GetAllTeachersByDepartmentId(int departmrntId)
        //{
        //    TeacherGateway gateway = new TeacherGateway();
        //    return gateway.GetAllTeachersByDepartmentId(departmrntId);

        //}
    }
}