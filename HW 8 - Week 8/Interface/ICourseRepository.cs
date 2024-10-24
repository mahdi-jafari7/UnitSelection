using HW_8___Week_8.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_8___Week_8.Interface
{
    public interface ICourseRepository
    {
        void AddCourse(Course course);
        void DeleteCourse(int courseId);
        List<Course> GetAllCourses();

    }
}
