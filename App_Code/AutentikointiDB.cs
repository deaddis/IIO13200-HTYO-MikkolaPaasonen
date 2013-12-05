using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

/// <summary>
/// Summary description for AutentikointiDB
/// </summary>
public static class AutentikointiDB
{
    public static string ConnectionString;
    private static MySqlConnection myConn;
    public static string email;
    private static bool OpenMyConnection()
    {
        try
        {
            myConn = new MySqlConnection(ConfigurationManager.ConnectionStrings["connstr"].ToString());
            myConn.Open();
            return true;
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Print(ex.Message);
            return false;
        }
    }
    private static void CloseMyConnection()
    {
        try
        {
            if (myConn != null & myConn.State == System.Data.ConnectionState.Open)
                myConn.Close();
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Print(ex.Message);
        }
    }
    public static bool isUserNameInUse(string username)
    {
        try
        {
            bool loytyy = false;
            if (OpenMyConnection())
            {
                using (MySqlCommand command = new MySqlCommand("SELECT userName FROM user WHERE userName LIKE @Parametri", myConn))
                {
                    MySqlParameter param = new MySqlParameter("Parametri", MySqlDbType.VarChar);
                    param.Value = username;
                    command.Parameters.Add(param);
                    using (MySqlDataReader rdr = command.ExecuteReader())
                    {
                        if (rdr.Read())
                            loytyy = true;
                        // break;
                        else
                            loytyy = false;
                    }
                }
                CloseMyConnection();
                return loytyy;
            }
            else
            {
                throw new Exception("Cannot open myconnection to database");
            }
        }
        catch (Exception)
        {

            throw;
        }
    }
    public static bool CreateNewUser(string username, string email, string password, bool hashPassword)
    {
        try
        {
            if (OpenMyConnection())
            {
                string passu = password;
                if (hashPassword)
                    passu = JAMK.ICT.Security.SHA256Hash.getSHA256Hash(passu);
                string sql = string.Format("INSERT INTO user VALUES ('null','{0}','{1}','{2}')", username, email, passu);
                MySqlCommand command = new MySqlCommand(sql, myConn);
                command.ExecuteNonQuery();
                CloseMyConnection();
                return true;
            }
            else
            {
                throw new Exception("Cannot open myconnection to database");
            }
        }
        catch (Exception ex)
        {

            throw;
        }
    }
    public static bool Login(string username, string password)
    {
        // Tarkistetaan käyttäjä ja salasana tietokannasta
        //Kannassa salasana on häshättynä
        // Vaarallinen takaovi, jota ei kannata jättää tuotantokoodiin!
        try
        {
            bool backdoorInUse = false;
            if (backdoorInUse)
            {
                if (username == "jack" && password == "russel")
                {
                    return true;
                }
            }
            // Varsinainen tarkistus tietokannasta
            // ensin "pöljän pojan tarkistus"
            if (username.Length * password.Length == 0)
            {
                throw new Exception("Eipä yritetä tuollaisia");
            }
            else
            {
                // Häshätään käyttäjän antama password
                string hashattyPwd = JAMK.ICT.Security.SHA256Hash.getSHA256Hash(password);
                //Kokeillaan tietokannasta
                if (OpenMyConnection())
                {
                    username += "%";
                    string sqlQuery = @"SELECT count(*) FROM user WHERE userName LIKE @Parametri AND userPassword LIKE @Password";
                    MySqlCommand command = new MySqlCommand(sqlQuery, myConn);

                    //Lisätään komennolle kaksi parametria
                    MySqlParameter param = new MySqlParameter("Parametri", MySqlDbType.VarChar);
                    param.Value = username;
                    command.Parameters.Add(param);

                    MySqlParameter param2 = new MySqlParameter("Password", MySqlDbType.VarChar);
                    hashattyPwd += "%";
                    param2.Value = hashattyPwd;
                    command.Parameters.Add(param2);

                    //Suoritetaan kysely kantaan
                    object i = command.ExecuteScalar();
                    
                    if (Convert.ToInt32(i) == 1)
                        return true;
                    else
                        return false;
                }
                else
                {
                    return false;
                }
            }
            //return false;
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Print(ex.Message);
            return false;
        }

    }

    public static string getAccountInfo(string account)
    {
        try
        {
            OpenMyConnection();
            MySqlCommand cmd = new MySqlCommand("SELECT userEmail FROM user WHERE userName LIKE @searchText");
            cmd.CommandText = "user";
            cmd.Connection = myConn;
            cmd.CommandType = CommandType.TableDirect;
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                email = reader.GetString("userEmail");
            }
            CloseMyConnection();
            return email;
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Print(ex.Message);
            return "Virhe tietokannassa";
        }
    }

    public static bool changePassword(string user, string oldPass, string newPass)
    {
        try
        {
            if (OpenMyConnection())
            {
                if (Login(user, oldPass))
                {
                    string hashattyPwd = JAMK.ICT.Security.SHA256Hash.getSHA256Hash(newPass);
                    string sqlQuery = @"UPDATE user SET userPassword=@Password WHERE userName=@Parametri;";
                    MySqlCommand command = new MySqlCommand(sqlQuery, myConn);

                    //Lisätään komennolle kaksi parametria
                    MySqlParameter param = new MySqlParameter("Parametri", MySqlDbType.VarChar);
                    param.Value = user;
                    command.Parameters.Add(param);

                    MySqlParameter param2 = new MySqlParameter("Password", MySqlDbType.VarChar);
                    hashattyPwd += "%";
                    param2.Value = hashattyPwd;
                    command.Parameters.Add(param2);
                    command.ExecuteScalar();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Print(ex.Message);
            return false;
        }
    }

    public static bool addEncounter(string uName, string eName, string eLevel, string eDesc, string eMonsters)
    {
        try
        {
            if (OpenMyConnection())
            {
                string userIDstring = "";

                MySqlCommand cmd = new MySqlCommand("SELECT userID FROM user WHERE userName LIKE '" + uName+ "';");
                //cmd.CommandText = uName;
                
                cmd.Connection = myConn;
                //cmd.CommandType = CommandType.TableDirect;
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    userIDstring = reader.GetString("userid");
                }
                CloseMyConnection();
                int userID = Convert.ToInt32(userIDstring);
                OpenMyConnection();
                string sql = "INSERT INTO encounter (user_userID, encounterName, encounterLevel, encounterDesc, encounterMonsters) VALUES ('" + userID + "','" + eName + "','" + eLevel + "','" + eDesc + "','" + eMonsters + "');";
                
                MySqlCommand command = new MySqlCommand(sql, myConn);
                command.ExecuteNonQuery();
                CloseMyConnection();
                return true;
            }
            else return false;
        }
        catch (Exception ex) 
        {
            System.Diagnostics.Debug.Print(ex.Message);
            return false;
        }
    }

    public static string getEncounterMonsters(string haku)
    {
        try
        {
            string palautus = "";
            OpenMyConnection();
            MySqlCommand cmd = new MySqlCommand("SELECT encounterMonsters FROM encounter WHERE eName LIKE '" + haku + "';");

            cmd.Connection = myConn;
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                palautus = reader.GetString("userid");
            }
            CloseMyConnection();
            return palautus;
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Print(ex.Message);
            return null;
        }

    }

    public static DataSet getDataSet(string haku)
    {
        try
        {
            OpenMyConnection();
            MySqlDataAdapter daHaku;
            DataSet dsHaku;
            daHaku = new MySqlDataAdapter(haku, myConn);
            MySqlCommandBuilder cb = new MySqlCommandBuilder(daHaku);

            dsHaku = new DataSet();
            daHaku.Fill(dsHaku, "encounter");


            return dsHaku;
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.Print(ex.Message);
            return null;
        }
    }
}

