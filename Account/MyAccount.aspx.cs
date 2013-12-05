using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Account_MyAccount : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try {
            myName.Text = User.Identity.Name;
            //string email;

            myEmail.Text = AutentikointiDB.getAccountInfo(User.Identity.Name);
        }

        catch (Exception)
        {
            throw;
        }
    }
}