using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DnDHarpake;

public partial class MonsteritEiHaku : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Monsters monsut = new Monsters();
        List<Monster> lista;
        List<Monster> tulokset = new List<Monster>();
        Serialisointi.DeSerialisoiXmlMonsterit(Server.MapPath("~/App_Data/monsters.xml"), ref monsut);
        lista = monsut.monster;
        List<string> mnimet = new List<string>();
        mnimet = parsiAppMonsterit(Application["MonsteritEiHaku"].ToString());


        foreach (Monster m in lista)
        {
            foreach (string s in mnimet) 
            {
                if (m.name == s) tulokset.Add(m);
            }
        }
        RepeaterMonsters.DataSource = tulokset;
        RepeaterMonsters.DataMember = "Monster";
        RepeaterMonsters.DataBind();
    }
    /*
    protected void Page_Close(object sender, EventArgs e)
    {
        Application["MonsteritEiHaku"] = "";
    }*/

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
}