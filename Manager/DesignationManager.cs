using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementApp.Gateway;
using UniversityManagementApp.Models;

namespace UniversityManagementApp.Manager
{
    public class DesignationManager
    {
        public List<Designation> GetAll()
        {
            DesignationGateway gateway = new DesignationGateway();
            return gateway.GetAll();
        }
    }
}