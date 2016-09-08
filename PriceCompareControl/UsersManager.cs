using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriceCompareControl.DataProvider;

namespace PriceCompareControl
{
    public class UsersManager : IUsersManager
    {
        private readonly IUsersEngine _usersEngine = new XmlUsersEngine();

        public bool CheckUserNameAndPassword(string userName, string password)
        {
            return _usersEngine.CheckUserNameAndPassword(userName, password);
        }

        public bool AddNewUser(string userName, string password)
        {
            return _usersEngine.AddNewUser(userName, password);
        }
    }
}
