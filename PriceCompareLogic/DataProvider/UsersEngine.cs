﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PriceCompareLogic.DataProvider
{
    internal class UsersEngine : IUsersEngine
    {
        public bool CheckUserNameAndPassword(string userName, string password)
        {
            var user = UsersAccessor.CheckUserName(userName);
            var xElements = user as XElement[] ?? user.ToArray();
            return xElements.Length != 0 && UsersAccessor.CheckPassword(xElements.ToArray()[0], password);
        }

        public bool AddNewUser(string userName, string password)
        {
            if (UsersAccessor.CheckUserName(userName).Any())
            {
                return false;
            }
            UsersAccessor.AddNewUser(userName,password);
            return true;
        }
    }
}
