using System;
using System.Web.UI.WebControls;

namespace SD.Web.Views
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            var userBus = new Business.SDManager();
           if (  userBus.IsValidLogin( Login1.UserName , Login1.Password) )
           {

                           System.Web.Security.FormsAuthentication.RedirectFromLoginPage( Login1.UserName , false);
           }
        }
    }
}
