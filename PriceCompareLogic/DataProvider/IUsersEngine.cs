namespace PriceCompareLogic.DataProvider
{
    internal interface IUsersEngine
    {
        bool CheckUserNameAndPassword(string userName, string password);

        bool AddNewUser(string userName, string password);
    }
}