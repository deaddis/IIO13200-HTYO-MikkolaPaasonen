using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DnDHarpake;

public partial class Lisaa : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnLisaa_Click(object sender, EventArgs e)
    {
        string powerType1 = "m";
        string powerType2 = "m";
        string powerType3 = "m";
        if (powMain1.Checked) powerType1 = "M";
        if (powMain2.Checked) powerType2 = "M";
        if (powMain3.Checked) powerType3 = "M";

        Monsters monsut = new Monsters(monNimi.Text, monLevel.Text, monRole.Text, monType.Text, monExp.Text, monHP.Text, monBloodied.Text, monInit.Text, monAC.Text,
            monFort.Text, monRef.Text, monWill.Text, monSenses.Text, monSpeed.Text, monResist.Text, monSaves.Text, monAP.Text, monSkills.Text,
            monStr.Text, monDex.Text, monWis.Text, monCon.Text, monInt.Text, monCha.Text, monAlign.Text, monLang.Text, monEquip.Text,
            powerType1, powName1.Text, powAvail1.Text, powType1.Text, powDesc1.Text, powerType2, powName2.Text, powAvail2.Text, powType2.Text, powDesc2.Text,
            powerType3, powName3.Text, powAvail3.Text, powType3.Text, powDesc3.Text);
        
        Serialisointi.WriteFile(Server.MapPath("~/App_Data/monsters.xml"), ref monsut);

    }
}