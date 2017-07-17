using SD.DataAccess;
using SD.Entities;

namespace SD.Business
{
    public class SDManager
    {
        public bool IsValidLogin(string userName, string password)
        {
            //if (string.IsNullOrEmpty(userName)) return false;
            //var userDAO = new UserDao();
            //User result = userDAO.GetUser(userName, password);
            //return (result != null);
            // FOR DEMO, Function always return TRUE
            return true;
        }
    }
}