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
        String dbName = "tamilsong";
        String titleTable = "songname";
        String contentTable = "song";

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
            int songNumber = int.Parse(snum);
            //SQLServerSettings sss = new SQLServerSettings(dbName);
            //string connectionString = sss.connectionString;
            MySqlConnection con;
            MySqlCommand cmd = null;
            string result = null;
            MySqlCommand cmdd = null;
            string result1 = null;
            try
            {
                con = new MySqlConnection(SQLServerSettings.getConnectionString(dbName));
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert(SQL Connection Failed : '" + ex.Message + "')</script>");
                return;
            }
                
            try
            {
                con.Open();
                cmd = new MySqlCommand("Select " + titleTable + " from songname where songnumber=" + songNumber , con);
                cmdd = new MySqlCommand("Select para from " + contentTable + " where songnumber=" + songNumber + " and stanzanumber=1", con);
                result = (string)cmd.ExecuteScalar();
                result1 = (string)cmdd.ExecuteScalar();
                header.Text = result;
                var outputHtml = result1.Replace("\r\n", "<br />").Replace("\n", "<br />").Replace("\r", "<br />");
                message.Text = outputHtml;
                con.Close();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert(Exception in Selecting Song : '" + ex.Message + "')</script>");
                con.Close();
            }
            

        }

        protected void Nextstanza(int a)
        {
            
            try
            {
                string connectionString = "server =localhost; Uid=root; password =Chris123# ; persistsecurityinfo = True; database =tamilsong; SslMode = none";
                MySqlConnection con = new MySqlConnection(connectionString);
                MySqlCommand cmdTitle = null;
                string songTitle = null;
                MySqlCommand cmdContent = null;
                string songContent = null;
                try
                {
                    string query1 = "Select para from song where songnumber=1 and stanzanumber='" + a + "'";
                    con.Open();
                    cmdTitle = new MySqlCommand("Select songname from songname where songnumber=1", con);
                    cmdContent = new MySqlCommand(query1, con);
                    songTitle = (string)cmdTitle.ExecuteScalar();
                    songContent = (string)cmdContent.ExecuteScalar();
                    header.Text = songTitle;
                    var outputHtml = songContent.Replace("\r\n", "<br />").Replace("\n", "<br />").Replace("\r", "<br />");
                    message.Text = outputHtml;
                    con.Close();
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "')</script>");
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
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
    