using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;
using System.Xml.Serialization;
using System.IO;

public partial class Monsterit : System.Web.UI.Page
{
    #region Käytetyt luokat
    public class Serialisointi
    {
        public static void DeSerialisoiXmlMonsterit(string filePath, ref Monsters monsut)
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(Monsters));
            try
            {
                FileStream xmlFile = new FileStream(filePath, FileMode.Open);
                monsut = (Monsters)deserializer.Deserialize(xmlFile);
                xmlFile.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
        }
    }

    [Serializable()]
    [XmlRoot("Monsters")]
    public class Monsters
    {
        public Monsters()
        {
            monster = new List<Monster>();

        }

        [XmlElement("Monster")]
        public List<Monster> monster { get; set; }

    }

    [Serializable()]
    public class Monster
    {
        [XmlAttribute("MonsterID")]
        public string MonsterID { get; set; }
        [XmlAttribute("creator")]
        public string creator { get; set; }
        [XmlAttribute("name")]
        public string name { get; set; }
        [XmlAttribute("Level")]
        public string Level{ get; set; }
        [XmlAttribute("Role")]
        public string Role { get; set; }
        [XmlAttribute("Type")]
        public string Type { get; set; }
        [XmlAttribute("XP")]
        public string XP { get; set; }
        [XmlAttribute("Init")]
        public string Init { get; set; }
        [XmlAttribute("Senses")]
        public string Senses { get; set; }
        [XmlAttribute("HP")]
        public string HP { get; set; }
        [XmlAttribute("Bloodied")]
        public string Bloodied { get; set; }
        [XmlAttribute("AC")]
        public string AC { get; set; }
        [XmlAttribute("Fort")]
        public string Fort { get; set; }
        [XmlAttribute("Ref")]
        public string Ref { get; set; }
        [XmlAttribute("Will")]
        public string Will { get; set; }
        [XmlAttribute("Resist")]
        public string Resist { get; set; }
        [XmlAttribute("Saves")]
        public string Saves { get; set; }
        [XmlAttribute("Speed")]
        public string Speed { get; set; }
        [XmlAttribute("AP")]
        public string Ap { get; set; }
        [XmlAttribute("Align")]
        public string Align { get; set; }
        [XmlAttribute("Lang")]
        public string Lang { get; set; }
        [XmlAttribute("Skills")]
        public string Skills { get; set; }
        [XmlAttribute("Str")]
        public string Str { get; set; }
        [XmlAttribute("Dex")]
        public string Dex { get; set; }
        [XmlAttribute("Wis")]
        public string Wis { get; set; }
        [XmlAttribute("Con")]
        public string Con { get; set; }
        [XmlAttribute("Int")]
        public string Int { get; set; }
        [XmlAttribute("Cha")]
        public string Cha { get; set; }
        [XmlAttribute("Equipment")]
        public string Equipment { get; set; }

        [XmlElement("Attack")]
        public List<Attack> Attackit { get; set; }
        public Monster()
        {
            Attackit = new List<Attack>();
        }
    }
        [Serializable()]
         public class Attack
        {
            [XmlAttribute("type")]
            public string type {get; set;}
            [XmlAttribute("name")]
            public string name { get; set; }
            [XmlAttribute("avail")]
            public string avail { get; set; }
            [XmlAttribute("School")]
            public string School { get; set; }
            [XmlAttribute("Desc")]
            public string Desc { get; set; }
        }

    
    #endregion


    

    protected void Page_Load(object sender, EventArgs e)
    {
        //getMonsterit(sender,e);
    }

    protected void getMonsterit(object sender, EventArgs e)
    {
        Monsters monsut = new Monsters();
        List<Monster> lista;
        List<Monster> tulokset = new List<Monster>();
        Serialisointi.DeSerialisoiXmlMonsterit(Server.MapPath("~/App_Data/monsters.xml"), ref monsut);
        lista = monsut.monster;
        foreach (Monster m in lista)
        {

            // HC IFFILAUSE!
            if (
                (txtboxMonsterinTaso.Text != "" && m.Level == txtboxMonsterinTaso.Text) ||
                (txtboxMinHP.Text != "" && Convert.ToInt32(m.HP) >= Convert.ToInt32(txtboxMinHP.Text)) ||
                (txtboxMaksHP.Text != "" && Convert.ToInt32(m.HP) <= Convert.ToInt32(txtboxMaksHP.Text)) ||
                (txtboxSanaHaku.Text != "" && (
                (checkNimi.Checked && m.name.Contains(txtboxSanaHaku.Text)) ||
                (checkRooli.Checked && m.Role.Contains(txtboxSanaHaku.Text)) ||
                (checkRyhmittyma.Checked && m.Align.Contains(txtboxSanaHaku.Text)) ||
                (checkTyyppi.Checked && m.Type.Contains(txtboxSanaHaku.Text)) 
                ))
                )
            {
                tulokset.Add(m);
            }
            if (txtboxSanaHaku.Text != "" && checkKyvyt.Checked)
            {
                foreach (Attack a in m.Attackit)
                {
                    if (!a.name.Contains(txtboxSanaHaku.Text) && a.Desc.Contains(txtboxSanaHaku.Text))
                    {
                        tulokset.Add(m);
                    }
                }

            }
            
        }
        RepeaterMonsters.DataSource = tulokset;
        RepeaterMonsters.DataMember = "Monster";
        RepeaterMonsters.DataBind();
    }

    protected void RepeaterMonsters_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (Application["Monsterit"] != null) Application["Monsterit"] = Application["Monsterit"].ToString() + ((Button)e.CommandSource).Text + "|";
        else
        {
            Application["Monsterit"] = ((Button)e.CommandSource).Text + "|";
        }
        getMonsterit(source, e);
    }

        /*
        try
        {

            string haku = luoHakuString();

            daHaku = new MySqlDataAdapter(haku,connection);
            MySqlCommandBuilder cb = new MySqlCommandBuilder(daHaku);

            dsHaku = new DataSet();
            daHaku.Fill(dsHaku, "monster");

            
            repEvent.DataSource = dsHaku;
            repEvent.DataMember = "monster";
            repEvent.DataBind();

        }
        catch (Exception ex) 
        {
            // throw ex;
        }
        */
    
    /*
    private string luoHakuString()
    {
        string haku = "SELECT * FROM monster WHERE";
        if (txtboxMonsterinTaso.Text != "")
        {
            haku += " monsterLevel = '" + txtboxMonsterinTaso.Text + "' AND";
        }
        if (txtboxMonsterinTyyppi.Text != "")
        {
            haku += " monsterType LIKE '%" + txtboxMonsterinTyyppi.Text + "%' AND";
        }
        if (txtboxMonsterinRooli.Text != "")
        {
            haku += " monsterRole LIKE '%" + txtboxMonsterinRooli.Text + "%' AND";
        }
        if (txtboxAlignment.Text != "")
        {
            haku += " monsterAlignment LIKE '%" + txtboxAlignment.Text + "%' AND";

        }
        if (txtboxMinHP.Text != "")
        {
            haku += " monsterHP > '" + txtboxMinHP.Text + "' AND";

        }
        if (txtboxMaksHP.Text != "")
        {
            haku += " monsterHP < '" + txtboxMaksHP.Text + "' AND";

        }
        if (txtboxSanaHaku.Text != "")
        {
            if (txtboxMonsterinNimi.Text != "") //CHECKBOXIKSIMUUTTAMINEN
            {
                haku += " monsterName LIKE '%" + txtboxSanaHaku.Text + "%' AND";
            }
            if (txtboxMonsterinKyvyt.Text != "") //CHECKBOXIKSIMUUTTAMINEN
            {
                haku += " monsterSkills LIKE '%" + txtboxMonsterinKyvyt.Text + "%' AND";
            }
        }
        haku = haku.Substring(0, haku.Length - 4);
        
        //haku += ";";
        return haku;
    }
     */



}