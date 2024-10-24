//using HW_8___Week_8.Interface;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace HW_8___Week_8.Repo
//{
//    public class AuthRepository : IAuthService
//    {

//        public bool StudentLogin(string username, string password)
//        {
//            foreach (var item in Storage.StudentList)
//            {
//                if (item.UserName == username && item.Password == password)
//                {
//                    Storage.Currentuser = item;
//                    return true;
//                }

//            }
//            return false;
//        }

//        public bool TeacherLogin(string username, string password)
//        {
//            foreach (var item in Storage.TeachersList)
//            {
//                if (item.UserName == username && item.Password == password)
//                {
//                    Storage.Currentuser = item;
//                    return true;
//                }

//            }
//            return false;
//        }

//        public bool OperatorLogin(string username, string password)
//        {
//            foreach (var item in Storage.OperatorList)
//            {
//                if (item.UserName == username && item.Password == password)
//                {
//                    Storage.Currentuser = item;

//                    return true;
//                }

//            }
//            return false;
//        }

      
//    }
//}
