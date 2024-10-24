using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_8___Week_8.Entities
{
    public class Course
    {

        public int ID { get; set; }
        public string Name { get; set; }
        public int Units { get; set; }
        public string Instructor { get; set; }
        public int Capacity { get; set; }
        public int EnrolledStudents { get; set; } = 0;
        public string Prerequisite { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public Course(int id, string name, int units, string instructor, string prerequisite, int capacity, DateTime startTime, DateTime endTime)
        {
            ID = id;
            Name = name;
            Units = units;
            Instructor = instructor;
            Prerequisite = prerequisite;
            Capacity = capacity;
            StartTime = startTime;
            EndTime = endTime;
        }
    }
}
