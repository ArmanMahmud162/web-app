using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementApp.Gateway;
using UniversityManagementApp.Models;

namespace UniversityManagementApp.Manager
{
    public class ViewDepartmentManager
    {
        ViewDepartmentGateway viewDepartmentGateway=new ViewDepartmentGateway();
        public List<Department> GetAllDepartment()
        {
            return viewDepartmentGateway.GetAllDepartment();
        }
    }
}