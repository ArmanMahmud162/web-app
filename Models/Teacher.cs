using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagementApp.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public int ContactNo { get; set; }
        public int DepartmentId { get; set; }
        public int DesignationId { get; set; }
        public decimal CreditToBetaken { get; set; }
        public decimal RemainingCredit { get; set; }

    }
}