using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Account_Login : System.Web.UI.Page
{
  protected void Page_Load(object sender, EventArgs e)
  {
    RegisterHyperLink.NavigateUrl = "Register.aspx?ReturnUrl=" + HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
  }
  protected void LoginButton_Click(object sender, EventArgs e)
  {
    try
    {
        //koetetaan autentikoitua käyttämällä AutentikointiDB luokkaa
        // lisataan config.webistä
        AutentikointiDB.ConnectionString = ConfigurationManager.ConnectionStrings["connstr"].ConnectionString;
        if (AutentikointiDB.Login(LoginUser.UserName, LoginUser.Password))
        {
            lblNotes.Text = Page.User.ToString();
            FormsAuthentication.RedirectFromLoginPage(LoginUser.UserName, false);
        }
        else
        {
            lblNotes.Text = "Autentikointi epäonnistui";
        }
    }
    catch (Exception ex)
    {
        lblNotes.Text = ex.Message; // HUOM! ei lopullinen, vaan koodarin testauksen ajan.
        //lblNotes.Text = "Autentikointipalvelua ei voi käyttää, yritä hetken päästä uudestaan.";
      //throw;
    }
  }
}