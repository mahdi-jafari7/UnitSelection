using HW_8___Week_8.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_8___Week_8.Interface
{
    public interface IAuthService
    {

        public bool StudentLogin(string username, string password);
        public bool TeacherLogin(string username, string password);
        public bool OperatorLogin(string username, string password);

    }
}
