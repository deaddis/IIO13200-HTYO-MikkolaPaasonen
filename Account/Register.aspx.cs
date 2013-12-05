using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Account_Register : System.Web.UI.Page
{
    string GoBackToThisPage;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            GoBackToThisPage = Request.QueryString["ReturnUrl"];
            //TODO
        }
        catch (Exception ex)
        {
            ErrorMessage.Text = "Yhteyden luonti tietokantaan ei onnistu! " + ex.Message;
        }
    }

    protected void RegisterUser_CreatedUser(object sender, EventArgs e)
    {
    }

    protected void CreateUserButton_Click(object sender, EventArgs e)
    {
        //tarkistetaan että onko jo ko nimellä käyttäjää, jollei ole niin luodaan uusi
        try
        {
            // lisataan config.webistä
            AutentikointiDB.ConnectionString = ConfigurationManager.ConnectionStrings["connstr"].ConnectionString;
            if (AutentikointiDB.isUserNameInUse(UserName.Text))
            {
                ErrorMessage.Text = string.Format("Kayttajanimi {0} on jo olemassa, valitse jokin toinen", UserName.Text);
            }
            else
            {
                ErrorMessage.Text = "Luodaan uusi käyttäjä";
                AutentikointiDB.CreateNewUser(UserName.Text, Email.Text, Password.Text, true);
                ErrorMessage.Text = "Luotu uusi käyttäjä" + UserName.Text;
            }
        }
        catch (Exception ex)
        {
            ErrorMessage.Text = ex.Message;
        }
    }
}