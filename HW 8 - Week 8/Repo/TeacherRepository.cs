using HW_8___Week_8.Entities;
using HW_8___Week_8.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_8___Week_8.Repo
{
    public class TeacherRepository : ITeacherRepository
    {

        public void AddTeacher(Teacher teacher)
        {
            Storage.Teachers.Add(teacher);
        }

        public Teacher GetTeacherById(int teacherId)
        {
            return Storage.Teachers.FirstOrDefault(t => t.ID == teacherId);
        }

        public List<Teacher> GetAllTeachers()
        {
            return Storage.Teachers;
        }

        public List<Student> GetStudentsInCourse(int courseId)
        {
            var course = Storage.Courses.FirstOrDefault(c => c.ID == courseId);
            return Storage.Students.Where(s => s.TakenCourses.Contains(course)).ToList();
        }

    }
}
