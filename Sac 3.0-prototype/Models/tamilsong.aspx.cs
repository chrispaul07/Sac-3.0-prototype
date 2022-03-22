using System;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

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
        protected void Songfunction(string snum, string stnum)
        {
            //SQLServerSettings sss = new SQLServerSettings(dbName);
            //string connectionString = sss.connectionString;
            MySqlConnection con;
            MySqlCommand songname, songcontent, songcheck, stanzacheck;
            string titlename;
            string content;
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
                string songcheckquery = "Select songnumber from " + titleTable + " where songnumber=" + snum;
                songcheck = new MySqlCommand(songcheckquery, con);
                object songcheckobject = songcheck.ExecuteScalar();
                if (songcheckobject != null)
                {
                    songNumber = int.Parse(snum);
                }
                else
                {
                    throw new Exception("Song not found : ");
                }
                string stanzacheckquery = "Select stanzanumber from " + contentTable + " where songnumber=" + songNumber + " and stanzanumber=" + stnum;
                stanzacheck = new MySqlCommand(stanzacheckquery, con);
                object stanzacheckobject = stanzacheck.ExecuteScalar();
                if (stanzacheckobject != null)
                {
                    stanzaNumber = int.Parse(stnum);
                }
                else
                {
                    throw new Exception("Stanza not found : ");
                }
                string songnamequery = "Select songname from " + titleTable + " where songnumber=" + songNumber;
                songname = new MySqlCommand(songnamequery, con);
                object songnameobject = songname.ExecuteScalar();
                titlename = songnameobject.ToString();
                string songcontentquery = "Select para from " + contentTable + " where songnumber=" + songNumber + " and stanzanumber=" + stanzaNumber;
                songcontent = new MySqlCommand(songcontentquery, con);
                object songcontentobject = songcontent.ExecuteScalar();
                content = songcontentobject.ToString();
                header.Text = titlename;
                var outputHtml = content.Replace("\r\n", "<br />").Replace("\n", "<br />").Replace("\r", "<br />");
                message.Text = outputHtml;
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
                con.Close();
            }
            

        }

        protected void Nextstanza(int stznumber)
        {
            stanzaNumber = stznumber;
            Songfunction(songNumber.ToString(), stanzaNumber.ToString());
            }

     
        protected void Get_Song(object sender, EventArgs e)
        {
            string songnum = TextBox.Text;
            string stanzanum = "1";
            Songfunction(songnum, stanzanum);
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
    