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
    public partial class tamilbible : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            SetDefaultButton(TextBox, Button1);
        }

        private void SetDefaultButton(TextBox txt, Button defaultButton)

        {
            txt.Attributes.Add("onkeydown", "funfordefautenterkey1(" + defaultButton.ClientID + ",event)");
        }
        protected void Bversefunction(string[] arr)
        {
            try
            {
                string cname = arr[0];
                int cnumber = int.Parse(arr[1]);
                int vnumber = int.Parse(arr[2]);
                string mycon = "server =sacv3-prototype.mysql.database.azure.com; Uid=user007; password =1Chris@p! ; persistsecurityinfo = True; database =tamilbible; SslMode = none";
                MySqlConnection con = new MySqlConnection(mycon);
                MySqlCommand cmd = null;
                string result = null;
                MySqlCommand cmdd = null;
                string result1 = null;
                try
                {
                    cmd = new MySqlCommand("Select bookname from books where bookid=1", con);
                    cmdd = new MySqlCommand("Select verse from bible where bookid=1 and chapternumber=1 and versenumber=1", con);
                    con.Open();
                    result = (string)cmd.ExecuteScalar();
                    result1 = (string)cmdd.ExecuteScalar();
                    header.Text = result + ":" + cnumber + ":" + vnumber;
                    message.Text = result1;
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
            string bverse = TextBox.Text;
            string[] textSplit = bverse.Split('.');
            Bversefunction(textSplit);
        }
    }
}
    