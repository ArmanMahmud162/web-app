using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementApp.Models
{
    public class AssignCourse
    {
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public int TeacherId { get; set; }
        public int CreditToBeTaken { get; set; }
        public int RemainingCredit { get; set; }
        [Display(Name = "Course")]
        public int CourseId { get; set; }
        //public int CourseName { get; set; }
        // public int Credit { get; set; }
        public string Action { get; set; }
      
    }
}