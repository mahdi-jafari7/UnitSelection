using HW_8___Week_8.Entities;
using HW_8___Week_8.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_8___Week_8.Repo
{
    public class StudentRepository : IStudentRepository
    {

        public void AddStudent(Student student)
        {
            Storage.Students.Add(student);
        }

        public Student GetStudentByCode(string studentCode)
        {
            return Storage.Students.FirstOrDefault(s => s.StudentCode == studentCode);
        }

        public List<Student> GetAllStudents()
        {
            return Storage.Students;
        }

        public void RegisterCourse(string studentCode, int courseId)
        {
            var student = GetStudentByCode(studentCode);
            var course = Storage.Courses.FirstOrDefault(c => c.ID == courseId);
            var sum = 0;
            foreach (var c in student.TakenCourses)
            {
                sum = +c.Units;
            }
            if (student != null && course != null && sum + course.Units <= 20 && course.EnrolledStudents < course.Capacity)
            {
                // ekhtelal zamani ro check mikonim
                foreach (var takenCourse in student.TakenCourses)
                {
                    if (takenCourse.StartTime > course.EndTime && course.StartTime < takenCourse.EndTime) //*
                    {
                        Console.WriteLine($"Cannot register for {course.Name}. It conflicts with {takenCourse.Name}.");
                        return;
                    }
                }

                student.TakenCourses.Add(course);
                course.EnrolledStudents++;
                Console.WriteLine($"Successfully registered for {course.Name}.");
            }
            else
            {
                Console.WriteLine("Cannot register for course. Either capacity is full or unit limit exceeded.");
            }
        }
    }
}

