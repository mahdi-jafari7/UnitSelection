using HW_8___Week_8.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_8___Week_8.Interface
{
    public interface IStudentRepository
    {

        void AddStudent(Student student);
        Student GetStudentByCode(string studentCode);
        List<Student> GetAllStudents();
        void RegisterCourse(string studentCode, int courseId);
    }
}
