using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Account
    {
        private string user;
        private string password;

        public string User { get => user; set => user = value; }
        public string Password { get => password; set => password = value; }

        public Account(string user, string pass)
        {
            User = user;
            Password = pass;
        }
    }
}
