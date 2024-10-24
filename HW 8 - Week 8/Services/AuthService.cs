using HW_8___Week_8.Entities;
using HW_8___Week_8.Enums;
using HW_8___Week_8.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_8___Week_8.Services
{
    public class AuthService
    {
        private readonly IAuthService authrepo;
        private readonly IStudentRepository studentrepo;
        private readonly ITeacherRepository teacherrepo;
        private readonly IOperatorRepository operatorrepo;

        public int login(string username, string password, RoleEnum role)
        {
            switch (role)
            {
                case RoleEnum.Student:
                    authrepo.StudentLogin(username, password);
                    return 1;
                    
                    break;
                case RoleEnum.Teacher:
                    authrepo.TeacherLogin(username, password);
                    return 2;
                    break;
                case RoleEnum.Operator:
                    authrepo.OperatorLogin(username, password);
                    return 3;
                    break;
                default:
                    return 100;
            }

        }

        public void StudentRegister(int id,string firstname, string lastname, string username, string password, string studentcode)
        {
            Student newstudent = new Student(id,firstname,lastname,username,password,RoleEnum.Student,studentcode);
            studentrepo.AddStudent(newstudent);
            Console.WriteLine($"{newstudent.UserName} has been successfully Registered!");

        }

        public void TeacherRegister(int id, string firstname, string lastname, string username, string password, RoleEnum role)
        {
            Teacher newteacher = new Teacher(id, firstname, lastname, username, password, RoleEnum.Teacher);
            teacherrepo.AddTeacher(newteacher);
            Console.WriteLine($"{newteacher.UserName} has been successfully Registered!");
        }

        public void OperatorRegister(int id, string firstname, string lastname, string username, string password, RoleEnum role)
        {
            Operator newoperator = new Operator(id, firstname, lastname, username, password, RoleEnum.Operator);
            operatorrepo.AddOperator(newoperator);
            Console.WriteLine($"{newoperator.UserName} has been successfully Registered!");
        }
    }
}
