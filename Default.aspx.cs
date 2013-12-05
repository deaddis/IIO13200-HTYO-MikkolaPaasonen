using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Serialization;
using System.IO;

public partial class Home : System.Web.UI.Page
{

    #region Käytetyt luokat
    public class Serialisointi
    {
        public static void DeSerialisoiXml(string filePath, ref Uutiset uutiset)
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(Uutiset));
            try
            {
                FileStream xmlFile = new FileStream(filePath, FileMode.Open);
                uutiset = (Uutiset)deserializer.Deserialize(xmlFile);
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
    [XmlRoot("Uutiset")]
    public class Uutiset
    {
        public Uutiset()
        {
            tyyppi = new Tyyppi();

        }

        [XmlElement("tyyppi")]
        public Tyyppi tyyppi { get; set; }

    }

    [Serializable()]
    public class Tyyppi
    {
        [XmlAttribute("name")]
        public string name { get; set; }
        [XmlElement("uutinen")]
        public List<Uutinen> Uutiset { get; set; }
        public Tyyppi()
        {
            Uutiset = new List<Uutinen>();
        }
    }

    [Serializable()]
    public class Uutinen
    {
        [XmlAttribute("DATE")]
        public string DATE { get; set; }
        [XmlAttribute("Otsikko")]
        public string Otsikko { get; set; }
        [XmlAttribute("Kirjoitus")]
        public string Kirjoitus { get; set; }
        [XmlAttribute("Kirjoittaja")]
        public string Kirjoittaja { get; set; }
    }
    #endregion

    public List<Uutinen> Albums { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            initStuff();
        }
        else
        {
            Albums = (List<Uutinen>)ViewState["Uutiset"];
        }
    }

    private void initStuff()
    {
        try
        {
            Uutiset uutiset = new Uutiset();
            Serialisointi.DeSerialisoiXml(Server.MapPath("~/App_Data/uutiset.xml"), ref uutiset);
            Albums = uutiset.tyyppi.Uutiset;
            ViewState["Uutiset"] = Albums;
            loadListWiew(Albums);
        }
        catch (Exception ex)
        {
            er.InnerText = ex.Message;
        }
    }

    protected void loadListWiew(List<Uutinen> r)
    {
        ViewState["currentUutiset"] = r;
        ListView1.DataSource = r;
        ListView1.DataBind();
    }

    protected void OpenAlbum_Click(object sender, EventArgs e)
    {
        LinkButton button = sender as LinkButton;
        string date = button.CommandArgument;
        ListView1.DataSource = null;
        ListView1.DataBind();
        List<Uutinen> uutinen = Albums.FindAll(
        delegate(Uutinen r) { return r.DATE == date; });
        ListView2.DataSource = uutinen;
        ListView2.DataBind();
    }

    protected void Back_Click(object sender, EventArgs e)
    {
        ListView2.DataSource = null;
        ListView2.DataBind();
        loadListWiew(Albums);
    }
}