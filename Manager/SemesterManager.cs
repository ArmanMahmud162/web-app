using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementApp.Gateway;
using UniversityManagementApp.Models;

namespace UniversityManagementApp.Manager
{
    public class SemesterManager
    {
        public List<Semester> GetAll()
        {
            SemesterGateway gateway = new SemesterGateway();
            return gateway.GetAll();
        }
    }
}