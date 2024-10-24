using HW_8___Week_8.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_8___Week_8.Interface
{
    public interface ITeacherRepository
    {
        void AddTeacher(Teacher teacher);
        Teacher GetTeacherById(int teacherId);
        List<Teacher> GetAllTeachers();
        List<Student> GetStudentsInCourse(int courseId);
    }
}
