using HW_8___Week_8.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_8___Week_8.Interface
{
    public interface IOperatorRepository
    {
        void AddOperator(Operator op);
        List<Operator> GetAllOperators();
        void ActivateStudent(string studentCode);
        void DeactivateStudent(string studentCode);
    }
}
