namespace PriceCompareControl.Strings
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

        //ItemsSelectionForm
        public static string ItemSelectionWindowName { get; } = "Price Compare App";
        public static string UserNameLabel { get; } = "Hello ";
        public static string SelectButton { get; } = "Start Compare";
        public static string UpdateButton { get; } = "Update stores";
        public static string InvalidQty { get; } = "You try to insert invalid Qty in item no:";
        public static string ExelButton { get; } = "Export to Exel";
        //End Of ItemsSelectionForm


        public static string StoreWindowName { get; } = "Store Window";
        public static string ChainNameLabel { get; } = "Chain Name:";
        public static string SubChainNameLabel { get; } = "Sub Chain Name:";
        public static string StoreNameLabel { get; } = "Store Name:";
        public static string AddressLabel { get; } = "Address:";
        public static string CityLabel { get; } = "City:";
        public static string MinLabel { get; } = "3 cheapes items";
        public static string MaxLabel { get; } = "3 most expansive items";
        public static string AllItems { get; } = "All items in shopping cart";
    }
}
