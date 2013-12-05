using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace DnDHarpake
{
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
        public static void SerialisoiXmlMonsterit(string filePath, ref Monsters monsut)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Monsters));
            try
            {
                StreamWriter file = new StreamWriter(filePath);
                serializer.Serialize(file, monsut);
                file.Close();
            }
            catch (Exception ex)
            {

            }
        }
        public static void WriteFile(string filePath, ref Monsters monsut) 
        {
            Monsters vanhat = new Monsters();
            DeSerialisoiXmlMonsterit(filePath, ref vanhat);

            vanhat.monster.Add(monsut.monster[0]);
            SerialisoiXmlMonsterit(filePath, ref vanhat);

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

        public Monsters(string monNimi, string monLevel, string monRole, string monType, string monExp, string monHP, string monBloodied, string monInit, string monAC,
            string monFort, string monRef, string monWill, string monSenses, string monSpeed, string monResist, string monSaves, string monAP, string monSkills,
            string monStr, string monDex, string monWis, string monCon, string monInt, string monCha, string monAlign, string monLang, string monEquip,
            string powMain1, string powName1, string powAvail1, string powType1, string powDesc1, string powMain2, string powName2, string powAvail2, string powType2, string powDesc2,
            string powMain3, string powName3, string powAvail3, string powType3, string powDesc3)
        {
            monster = new List<Monster>();
            monster.Add(new Monster(monNimi, monLevel, monRole, monType, monExp, monHP, monBloodied, monInit, monAC, 
            monFort, monRef, monWill, monSenses, monSpeed, monResist, monSaves, monAP, monSkills, 
            monStr, monDex, monWis, monCon, monInt, monCha, monAlign, monLang, monEquip, 
            powMain1, powName1, powAvail1, powType1, powDesc1, powMain2, powName2, powAvail2, powType2, powDesc2,
            powMain3, powName3, powAvail3, powType3, powDesc3));

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
        public string Level { get; set; }
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

        public Monster(string monNimi, string monLevel, string monRole, string monType, string monExp, string monHP, string monBloodied, string monInit, string monAC, 
            string monFort, string monRef, string monWill, string monSenses, string monSpeed, string monResist, string monSaves, string monAP, string monSkills, 
            string monStr, string monDex, string monWis, string monCon, string monInt, string monCha, string monAlign, string monLang, string monEquip, 
            string powMain1, string powName1, string powAvail1, string powType1, string powDesc1, string powMain2, string powName2, string powAvail2, string powType2, string powDesc2,
            string powMain3, string powName3, string powAvail3, string powType3, string powDesc3)
        {
            this.name = monNimi;
            this.Level = monLevel;
            this.Role = monRole;
            this.Type = monType;
            this.XP = monExp;
            this.HP = monHP;
            this.Bloodied = monBloodied;
            this.Init = monInit;
            this.AC = monAC;
            this.Fort = monFort;
            this.Ref = monRef;
            this.Will = monWill;
            this.Senses = monSenses;
            this.Speed = monSpeed;
            this.Resist = monResist;
            this.Saves = monSaves;
            this.Ap = monAP;
            this.Skills = monSkills;
            this.Str = monStr;
            this.Dex = monDex;
            this.Wis = monWis;
            this.Con = monCon;
            this.Int = monInt;
            this.Cha = monCha;
            this.Align = monAlign;
            this.Lang = monLang;
            this.Equipment = monEquip;

            
            Attackit = new List<Attack>();
            Attack a1 = new Attack(powMain1, powName1, powAvail1, powType1, powDesc1);
            Attack a2 = new Attack(powMain2, powName2, powAvail2, powType2, powDesc2);
            Attack a3 = new Attack(powMain3, powName3, powAvail3, powType3, powDesc3);
            Attackit.Add(a1);
            Attackit.Add(a2);
            Attackit.Add(a3);
            
        }

    }
    [Serializable()]
    public class Attack
    {
        public Attack() {

        }

        public Attack(string powMain1, string powName1, string powAvail1, string powType1, string powDesc1) {
            this.type = powMain1;
            this.name = powName1;
            this.avail = powAvail1;
            this.Desc = powDesc1;
            this.School = powType1;
        }

        [XmlAttribute("type")]
        public string type { get; set; }
        [XmlAttribute("name")]
        public string name { get; set; }
        [XmlAttribute("avail")]
        public string avail { get; set; }
        [XmlAttribute("School")]
        public string School { get; set; }
        [XmlAttribute("Desc")]
        public string Desc { get; set; }
    }
}