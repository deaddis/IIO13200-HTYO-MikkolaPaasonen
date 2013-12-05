using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

public partial class Encounterit : System.Web.UI.Page
{

    DataSet dsHaku;

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void getEncountterit(object sender, EventArgs e)
    {
            string haku = luoHakuString();

            dsHaku = AutentikointiDB.getDataSet(haku);
            
            RepeaterEncounters.DataSource = dsHaku;
            RepeaterEncounters.DataBind();
            
            

    }

    
        
        

    
    private string luoHakuString()
    {
        string haku = "SELECT * FROM encounter WHERE";
        if (txtboxKohtaamisenTaso.Text != "")
        {
            haku += " encounterLevel = '" + txtboxKohtaamisenTaso.Text + "' AND";
        }

        if (txtboxKohtaamisenExpMin.Text != "")
        {
            haku += " encounterExp >= '" + txtboxKohtaamisenExpMin.Text + "' AND";
        }

        if (txtboxKohtaamisenExpMaks.Text != "")
        {
            haku += " encounterExp <= '" + txtboxKohtaamisenExpMaks.Text + "' AND";
        }
        
        if (txtboxSanaHaku.Text != "")
        {
            if (checkNimi.Checked) 
            {
                haku += " encounterName LIKE '%" + txtboxSanaHaku.Text + "%' AND";
            }
            if (checkKuvaus.Checked)
            {
                if (checkNimi.Checked)
                {
                    haku = haku.Substring(0, haku.Length - 4);
                    haku += " OR";
                }
                haku += " encounterDesc LIKE '%" + txtboxSanaHaku.Text + "%' AND";
            }
        }
        haku = haku.Substring(0, haku.Length - 4);
        
        return haku;
    }

    public List<string> parsiAppMonsterit(string s)
    {
        List<string> lista = new List<string>();
        int i = 0;
        if (!s.Contains("|")) lista.Add(s);
        while (s.Contains("|"))
        {
            lista.Add(s.Substring(0, s.IndexOf("|")));
            s = s.Substring(s.IndexOf("|") + 1);
            i++;
        } 
        return lista;

    }

    protected void RepeaterEncounters_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        List<string> mosat = new List<string>();
        string apu;
        apu = ((Button)e.CommandSource).ToolTip;
        
        OpenWindow(apu);
    }

    protected void OpenWindow(string apu)
    {
        Application["MonsteritEiHaku"] = apu;
        string url = "MonsteritEiHaku.aspx";
        string s = "window.open('" + url + "');";
        ClientScript.RegisterStartupScript(this.GetType(), "script", s, true);
        
    }


}
/*if (Application["Monsterit"] != null) Application["Monsterit"] = Application["Monsterit"].ToString() + "|" + ((Button)e.CommandSource).Text;
        else
        {
            Application["Monsterit"] = ((Button)e.CommandSource).Text;
        }*/