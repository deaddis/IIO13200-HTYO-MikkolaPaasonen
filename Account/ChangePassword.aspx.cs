using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Account_ChangePassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void ChangePasswordPushButton_Click(object sender, EventArgs e)
    {
        string currentUser = User.Identity.Name;
        try
        {
            if (AutentikointiDB.changePassword(currentUser, ChangeUserPassword.CurrentPassword, ChangeUserPassword.NewPassword))
            {
                Response.Redirect("~/Account/ChangePasswordSuccess.aspx");
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
}