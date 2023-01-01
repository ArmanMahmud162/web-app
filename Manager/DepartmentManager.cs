using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementApp.Gateway;
using UniversityManagementApp.Models;

namespace UniversityManagementApp.Manager
{
    public class DepartmentManager
    {
        public string Save(Department department)
        {
            DepartmentGateWay gateway = new DepartmentGateWay();
            bool isCodeExit = gateway.IsCodeExist(department.Code);
            if (isCodeExit)
            {
                return "Sorry,Code already exist";
            }
            bool isNameExit = gateway.IsNameExist(department.Name);
            if (isNameExit)
            {
                return "Sorry,Name already exist";
            }
            int rowAffected = gateway.Save(department);
            if (rowAffected > 0)
            {
                return "Department saved";
            }
            return "Department save failed";
        }
    }
}