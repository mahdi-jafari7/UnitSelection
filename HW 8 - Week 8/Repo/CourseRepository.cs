using HW_8___Week_8.Entities;
using HW_8___Week_8.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_8___Week_8.Repo
{
    public class CourseRepository : ICourseRepository
    {

        public void AddCourse(Course course)
        {
            Storage.Courses.Add(course);
        }

        public void DeleteCourse(int courseId)
        {
            var course = Storage.Courses.FirstOrDefault(c => c.ID == courseId);
            if (course != null)
            {
                Storage.Courses.Remove(course);
            }
        }

        public List<Course> GetAllCourses()
        {
            return Storage.Courses;
        }
    }

}


