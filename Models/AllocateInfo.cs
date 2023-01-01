using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagementApp.Models
{
    public class AllocateInfo
    {
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int RoomId { get; set; }
        public string RoomNumber { get; set; }
        public int DayId { get; set; }
        public string Day { get; set; }
        public string Froms { get; set; }
        public string Tos { get; set; }
        public string Action { get; set; }
    }
}