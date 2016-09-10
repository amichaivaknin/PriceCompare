namespace PriceCompareControl
{
    public interface IUsersManager
    {
        bool CheckUserNameAndPassword(string userName, string password);

        bool AddNewUser(string userName, string password);
    }
}