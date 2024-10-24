using HW_8___Week_8.Entities;
using HW_8___Week_8.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_8___Week_8.Services
{

    public class Service
    {
        public readonly ICourseRepository courseRepo;
        public readonly IStudentRepository studentRepo;
        public readonly ITeacherRepository teacherRepo;
        public readonly IOperatorRepository operatorRepo; // Add operatorRepo here

        // Constructor to initialize the repositories
        public Service(ICourseRepository courseRepo, IStudentRepository studentRepo, ITeacherRepository teacherRepo, IOperatorRepository operatorRepo)
        {
            this.courseRepo = courseRepo;
            this.studentRepo = studentRepo;
            this.teacherRepo = teacherRepo;
            this.operatorRepo = operatorRepo; // Initialize operatorRepo
        }

        public void CreateCourse(int teacherId)
        {
            var teacher = teacherRepo.GetTeacherById(teacherId);

            if (teacher == null)
            {
                Console.WriteLine("Teacher not found.");
                return;
            }

            Console.WriteLine("Enter course name:");
            string courseName = Console.ReadLine();

            Console.WriteLine("Enter the number of units:");
            int units = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the course capacity:");
            int capacity = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the prerequisite (if any):");
            string prerequisite = Console.ReadLine();

            Console.WriteLine("Enter the course start time (format: yyyy-MM-dd HH:mm):");
            string startTimeInput = Console.ReadLine();

            Console.WriteLine("Enter the course end time (format: yyyy-MM-dd HH:mm):");
            string endTimeInput = Console.ReadLine();

            DateTime startTime;
            DateTime endTime;

            try
            {
                startTime = DateTime.ParseExact(startTimeInput, "yyyy-MM-dd HH:mm", null);
                endTime = DateTime.ParseExact(endTimeInput, "yyyy-MM-dd HH:mm", null);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid date format. Please use the format yyyy-MM-dd HH:mm.");
                return;
            }

            Course newCourse = new Course(Storage.Courses.Count + 1, courseName, units, teacher.FirstName + " " + teacher.LastName, prerequisite, capacity, startTime, endTime);
            courseRepo.AddCourse(newCourse);
            teacher.CoursesTaught.Add(newCourse);

            Console.WriteLine($"Course {courseName} created successfully by {teacher.FirstName} {teacher.LastName}.");
        }
    }
}
