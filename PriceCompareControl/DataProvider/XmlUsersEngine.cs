using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PriceCompareControl.DataProvider
{
    internal class XmlUsersEngine:IUsersEngine
    {
        public bool CheckUserNameAndPassword(string userName, string password)
        {
            var user = XmlUsersAccessor.CheckUserName(userName);
            var xElements = user as XElement[] ?? user.ToArray();
            return xElements.Length != 0 && XmlUsersAccessor.CheckPassword(xElements.ToArray()[0], password);
        }

        public bool AddNewUser(string userName, string password)
        {
            if (XmlUsersAccessor.CheckUserName(userName).Any())
            {
                return false;
            }
            XmlUsersAccessor.AddNewUser(userName, password);
            return true;
        }
    }
}
