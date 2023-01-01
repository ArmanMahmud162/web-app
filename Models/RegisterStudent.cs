using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagementApp.Models
{
    public class RegisterStudent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int ContactNo { get; set; }
        public string Date { get; set; }
        public string Address { get; set; }
        public int DepartmentId { get; set; }
        public string RegNo { get; set; }
    }
}