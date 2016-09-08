using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCompareControl.DataProvider
{
    internal interface IUsersEngine
    {
        bool CheckUserNameAndPassword(string userName, string password);

        bool AddNewUser(string userName, string password);
    }
}
