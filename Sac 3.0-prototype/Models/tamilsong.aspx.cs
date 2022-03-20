using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace Sac_3._0_prototype.Models
{
    public partial class tamilsong : System.Web.UI.Page
    {
        readonly String dbName = "tamilsong";
        readonly String titleTable = "songname";
        readonly String contentTable = "song";
        static int songNumber,stanzaNumber;

        protected void Page_Load(object sender, EventArgs e)
        {
            SetDefaultButton(TextBox, Button1);
        }

        private void SetDefaultButton(TextBox txt, Button defaultButton)

        {
            txt.Attributes.Add("onkeydown", "funfordefautenterkey1(" + defaultButton.ClientID + ",event)");
        }
        protected void Songfunction(string snum)
        {
            songNumber = int.Parse(snum);
            //SQLServerSettings sss = new SQLServerSettings(dbName);
            //string connectionString = sss.connectionString;
            MySqlConnection con;
            MySqlCommand query1, query2, songcheck, stanzacheck;
            string titlename;
            string songcontent;
            try
            {
                con = new MySqlConnection(SQLServerSettings.GetConnectionString(dbName));
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert(SQL Connection Failed : '" + ex.Message + "')</script>");
                return;
            }
                
            try
            {
                con.Open();
                stanzaNumber = 1;
                songcheck = new MySqlCommand("Select songnumber from " + titleTable + " where songnumber=" + songNumber, con);
                stanzacheck = new MySqlCommand("Select stanzanumber from " + contentTable + " where songnumber=" + songNumber + " and stanzanumber=" + stanzaNumber, con);
                query1 = new MySqlCommand("Select songname from " + titleTable +" where songnumber=" + songNumber , con);
                query2 = new MySqlCommand("Select para from " + contentTable + " where songnumber=" + songNumber + " and stanzanumber="+stanzaNumber, con);
                object obj1 = songcheck.ExecuteScalar();
                
                int otitlename = Convert.ToInt32(obj1);
                int osongcontent = (int)stanzacheck.ExecuteScalar();
                if (otitlename == songNumber && osongcontent == stanzaNumber)
                {
                    titlename = (string)query1.ExecuteScalar();
                    songcontent = (string)query2.ExecuteScalar();
                    header.Text = titlename;
                    var outputHtml = songcontent.Replace("\r\n", "<br />").Replace("\n", "<br />").Replace("\r", "<br />");
                    message.Text = outputHtml;
                }
                else
                {
                    throw new Exception("Song not found : ");
                }
                con.Close();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Exception in Selecting Song : '" + ex.Message + "')</script>");
                con.Close();
            }
            

        }

        protected void Nextstanza(int stznumber)
        {
            MySqlConnection con;
            MySqlCommand titlenamequery;
            string titlename;
            MySqlCommand songcontentquery;
            string songcontent;

            try
            {
                con = new MySqlConnection(SQLServerSettings.GetConnectionString(dbName));
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert(SQL Connection Failed : '" + ex.Message + "')</script>");
                return;
            }
                try
                {
                    con.Open();
                    stanzaNumber = stznumber;
                    titlenamequery = new MySqlCommand("Select " + titleTable + " from songname where songnumber=" + songNumber, con);
                    songcontentquery = new MySqlCommand("Select para from " + contentTable + " where songnumber=" + songNumber + " and stanzanumber=" + stanzaNumber, con);
                    if (songcontentquery != null)
                    {
                        titlename = (string)titlenamequery.ExecuteScalar();
                        songcontent = (string)songcontentquery.ExecuteScalar();
                        header.Text = titlename;
                        var outputHtml = songcontent.Replace("\r\n", "<br />").Replace("\n", "<br />").Replace("\r", "<br />");
                        message.Text = outputHtml;
                }
                    else
                    {
                        throw (new Exception("Stanza "+stanzaNumber+" not found : "));
                    }
                    con.Close();
            }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "')</script>");
                    con.Close();
                }
            }

     
        protected void ButtonIN_Click(object sender, EventArgs e)
        {
            string songnum = TextBox.Text;
            Songfunction(songnum);
        }
        protected void ButtonIN_Click1(object sender, EventArgs e)
        {
            Nextstanza(1);
        }
        protected void ButtonIN_Click2(object sender, EventArgs e)
        {
            Nextstanza(2);
        }
        protected void ButtonIN_Click3(object sender, EventArgs e)
        {
            Nextstanza(3);
        }

    }
}
    