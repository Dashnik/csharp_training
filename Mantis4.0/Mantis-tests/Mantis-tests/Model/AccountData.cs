﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mantis_tests
{
    public class AccountData
    {
        public AccountData()
        {

        }

        public AccountData(String name, String password)
        {
            Username = name;
            Password = password;         
        }

        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Id { get; set;}
        //test
    }
}
