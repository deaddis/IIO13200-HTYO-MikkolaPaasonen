using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DnDHarpake;


public partial class LisaaEncounter : System.Web.UI.Page
{
    List<string> appMonsut;

    protected void Page_Load(object sender, EventArgs e)
    {
        
        
    }

    public List<string> parsiAppMonsterit(string s)
    {
        List<string> lista = new List<string>();
        int i = 0;
        while (s.Contains("|")) 
        {
            lista.Add(s.Substring(0, s.IndexOf("|")));
            s = s.Substring(s.IndexOf("|") + 1);
            i++;
        }
        return lista;
        
    }

    protected void RepeaterMonsterit_ItemCommand1(object source, RepeaterCommandEventArgs e)
    {
        string apu = ((Button)e.CommandSource).ToolTip;
        string help = Application["Monsterit"].ToString();
        Application["Monsterit"] = help.Remove(help.IndexOf(apu), apu.Length);
        btnLataaMonsterit_Click(null, null);
    }


    protected void btnTallenna_Click(object sender, EventArgs e)
    {
        bool happy;
        happy = AutentikointiDB.addEncounter(User.Identity.Name,txtboxNimi.Text,txtboxTaso.Text, txtboxKuvaus.Text,Application["Monsterit"].ToString());

    }

    protected void btnLataaMonsterit_Click(object sender, EventArgs e)
    {
        if (Application["Monsterit"] != null)
        {
            Monsters monsut = new Monsters();
            List<Monster> lista;
            List<Monster> tulokset = new List<Monster>();
            Serialisointi.DeSerialisoiXmlMonsterit(Server.MapPath("~/App_Data/monsters.xml"), ref monsut);
            lista = monsut.monster;
            appMonsut = new List<string>();
            appMonsut = parsiAppMonsterit(Application["Monsterit"].ToString());
            foreach (Monster m in lista)
            {
                foreach (string s in appMonsut)
                {
                    if (m.name == s) tulokset.Add(m);
                }
            }
            RepeaterMonsterit.DataSource = tulokset;
            RepeaterMonsterit.DataMember = "Monster";
            RepeaterMonsterit.DataBind();
        }
    }
}