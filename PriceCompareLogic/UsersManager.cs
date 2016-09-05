using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriceCompareLogic.DataProvider;

namespace PriceCompareLogic
{
    public class UsersManager
    {
        private readonly IUsersEngine _usersEngine = new UsersEngine();

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
