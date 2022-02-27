using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data.MySqlClient;

namespace Sac_3._0_prototype.Models
{
    public partial class englishsong : System.Web.UI.Page
    {

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
            try
            {
                int vnumber = int.Parse(snum);
                string mycon = "server =localhost; Uid=root; password =Chris123# ; persistsecurityinfo = True; database =englishsong; SslMode = none";
                MySqlConnection con = new MySqlConnection(mycon);
                MySqlCommand cmd = null;
                string result = null;
                MySqlCommand cmdd = null;
                string result1 = null;
                try
                {
                    cmd = new MySqlCommand("Select songname from songname where songnumber=1", con);
                    cmdd = new MySqlCommand("Select para from song where songnumber=1 and stanzanumber=1", con);
                    con.Open();
                    result = (string)cmd.ExecuteScalar();
                    result1 = (string)cmdd.ExecuteScalar();
                    header.Text = result;
                    var outputHtml = result1.Replace("\r\n", "<br />").Replace("\n", "<br />").Replace("\r", "<br />");
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

        protected void Nextstanza(int a)
        {
            
            try
            {
                string mycon = "server =localhost; Uid=root; password =Chris123# ; persistsecurityinfo = True; database =englishsong; SslMode = none";
                MySqlConnection con = new MySqlConnection(mycon);
                MySqlCommand cmd = null;
                string result = null;
                MySqlCommand cmdd = null;
                string result1 = null;
                try
                {
                    string query1 = "Select para from song where songnumber=1 and stanzanumber='" + a + "'";
                    con.Open();
                    cmd = new MySqlCommand("Select songname from songname where songnumber=1", con);
                    cmdd = new MySqlCommand(query1,con);
                    result = (string)cmd.ExecuteScalar();
                    result1 = (string)cmdd.ExecuteScalar();
                    header.Text = result;
                    var outputHtml = result1.Replace("\r\n", "<br />").Replace("\n", "<br />").Replace("\r", "<br />");
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
    