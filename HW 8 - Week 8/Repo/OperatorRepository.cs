using HW_8___Week_8.Entities;
using HW_8___Week_8.Interface;
using HW_8___Week_8.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_8___Week_8.Repo
{
    public class OperatorRepository : IOperatorRepository
    {

        public void AddOperator(Operator op)
        {
            Storage.Operators.Add(op);
        }

        public List<Operator> GetAllOperators()
        {
            return Storage.Operators;
        }

        public void ActivateStudent(string studentCode)
        {
            var student = Storage.Students.FirstOrDefault(s => s.StudentCode == studentCode);
            if (student != null)
            {
                Storage.Students.FirstOrDefault(s => s.StudentCode == studentCode).IsActive = true;
                Console.WriteLine($"{student.FirstName} {student.LastName} has been activated.");
            }
        }

        public void DeactivateStudent(string studentCode)
        {
            var student = Storage.Students.FirstOrDefault(s => s.StudentCode == studentCode);
            if (student != null)
            {
                Storage.Students.FirstOrDefault(s => s.StudentCode == studentCode).IsActive = false;
                
                Console.WriteLine($"{student.FirstName} {student.LastName} has been deactivated.");
            }
        }
    }
}