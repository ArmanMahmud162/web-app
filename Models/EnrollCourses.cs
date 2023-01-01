using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagementApp.Models
{
    public class EnrollCourses
    {
        public int Id { get; set; }
        public int RegStudentId { get; set; }
        public int CourseId { get; set; }
        public String Date { get; set; }
    }
}