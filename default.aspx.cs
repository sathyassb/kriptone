using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
            //do the login.. 
            var arr = new[] { "admin"};
        if (txtUsername.Text == "admin" && txtPassword.Text == "123")
        {
            Authenticated("1", "admmin", arr.ToArray(), true);
            Response.Redirect("user-report");
        }
    }
    #region Authenticated
    /// <summary>
    /// Authenticateds the specified customer id.
    /// </summary>
    /// <param name="customerId">The customer id.</param>
    /// <param name="username">The username.</param>
    /// <param name="userDetails">The user details.</param>
    /// <param name="isPersistent">if set to <c>true</c> [is persistent].</param>
    private void Authenticated(string userId, string username, string[] userDetails, bool isPersistent)
    {
        var fat = new FormsAuthenticationTicket(1, username, DateTime.Now, DateTime.Now.AddMinutes(600), isPersistent, String.Join("|", userDetails), FormsAuthentication.FormsCookiePath);
        Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(fat)));
    }
    #endregion
}