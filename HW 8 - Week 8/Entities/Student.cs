using HW_8___Week_8.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_8___Week_8.Entities
{
    public class Student : User
    {

        public string StudentCode { get; set; }
        public bool IsActive { get; set; } = true;
        public List<Course> TakenCourses { get; set; } = new List<Course>();

        public Student(int id, string firstName, string lastName, string username, string password, RoleEnum role, string studentCode)
            : base(id, firstName, lastName, username, password, role)
        {
            StudentCode = studentCode;
        }
    }
}
