using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCompareControl
{
    public interface IUsersManager
    {
        bool CheckUserNameAndPassword(string userName, string password);
        bool AddNewUser(string userName, string password);
    }
}
