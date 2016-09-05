using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using PriceCompareLogic.Entities;

namespace PriceCompareLogic.DataProvider
{
    internal class UsersAccessor
    {
        internal static IEnumerable<XElement> CheckUserName(string userName)
        {
            var document = XDocument.Load(@"..\..\..\xmls\users.xml");
            var users = document.Element("Users");
            return (from user in users?.Descendants("User")
                        where user.Attribute("userName").Value==userName
                        select user);
        }

        internal static bool CheckPassword(XElement user,string password)
        {
            return user.Attribute("password").Value == password;
        }

        internal static void AddNewUser(string userName, string password)
        {
            var document = XDocument.Load(@"..\..\..\xmls\users.xml");
            document.Element("Users")?.Add(
                     new XElement(
                            "User",
                             new XAttribute("userName",userName),
                             new XAttribute("password",password),
                             new XElement("ShoppingCarts")
                              )
                            );
            document.Save(@"..\..\..\xmls\users.xml");
        }
    }
}
