
using HW_8___Week_8.Entities;
using HW_8___Week_8.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_8___Week_8
{
    public static class Storage
    {

        public static List<Student> Students = new List<Student>();
        public static List<Teacher> Teachers = new List<Teacher>();
        public static List<Operator> Operators = new List<Operator>();
        public static List<Course> Courses = new List<Course>();
        public static User CurrentUser { get; set; }

        static Storage()
        {
            // Initializing students
            Students.Add(new Student(1, "Mahdi", "Jafari", "mahdi.jafari", "mahdi123", RoleEnum.Student, "000123"));
            Students.Add(new Student(2, "Ali", "Rezai", "ali.rezai", "ali123", RoleEnum.Student, "000234"));

            // Initializing teachers
            Teachers.Add(new Teacher(1, "Dr. ", "Hiphopologist", "dr.Hiphopologist", "dr123", RoleEnum.Teacher));
            Teachers.Add(new Teacher(2, "dr", "dre", "Dr.Dre", "dr1234", RoleEnum.Teacher));

            // Initializing operators
            Operators.Add(new Operator(1, "Sajad", "Shahi", "sajad.shahi", "sajad123", RoleEnum.Operator));

            // Initializing courses
            Courses.Add(new Course(1, "Data Structures", 4, "Dr. Kazem Bahari", "None", 20,
                DateTime.ParseExact("2024-10-23 08:30", "yyyy-MM-dd HH:mm", null),
                DateTime.ParseExact("2024-10-23 10:30", "yyyy-MM-dd HH:mm", null)));

            Courses.Add(new Course(2, "Operating Systems", 4, "Dr. Reza Bahrami", "Data Structures", 25,
                DateTime.ParseExact("2024-10-25 11:00", "yyyy-MM-dd HH:mm", null),
                DateTime.ParseExact("2024-10-25 13:00", "yyyy-MM-dd HH:mm", null)));
        }
    }
}
