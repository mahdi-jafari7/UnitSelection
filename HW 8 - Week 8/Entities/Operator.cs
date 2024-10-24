using HW_8___Week_8.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_8___Week_8.Entities
{
    public class Operator : User
    {
        public Operator(int id, string firstName, string lastName, string username, string password, RoleEnum role)
        : base(id, firstName, lastName, username, password, role) { }


    }
}
