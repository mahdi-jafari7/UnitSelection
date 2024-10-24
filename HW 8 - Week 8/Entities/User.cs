using HW_8___Week_8.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_8___Week_8.Entities
{
    public  class User
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public RoleEnum Role { get; set; }

        public User(int id, string firstName, string lastName, string username, string password, RoleEnum role)
        {
            ID = id;
            FirstName = firstName;
            LastName = lastName;
            UserName = username;
            Password = password;
            Role = role;
        }
    }
}
