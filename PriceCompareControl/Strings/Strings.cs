using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceCompareControl.Stirngs
{
    public static class Strings
    {
        //LoginForm
        public static string LoginWindowName { get; } = "Login window";
        public static string WellcomeMessage { get; } = "Wellcome to Price Compare App";
        public static string UserNameMessage { get; } = "User Name";
        public static string PasswordMessage { get; } = "Password";
        public static string LoginButton { get; } = "Login";
        public static string SignUpButton { get; } = "New User";
        public static string UnRegisteredButton { get; } = "Continue as unregistered user";
        public static string InvalidUserNameOrPassword { get; } = "Invalid user name or password.\n" +
                                                                  "Please, insert the user name and password agian";
        public static string WorngUserNameOrPassword { get; } = "Worng user name or password.\n" +
                                                                  "Please, insert the user name and password agian";
        public static string UserAllreadyExists { get; } = "User allready exists, try a another user name";
        public static string NewUser { get; } = "User added successfully";
        //End of LoginForm

        public static string ItemSelectionWindowName { get; } = "Price Compare App";
        public static string UserNameLabel { get; } = "Hello ";
    }
}
