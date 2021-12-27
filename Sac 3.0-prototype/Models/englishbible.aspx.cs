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
    public partial class englishbible : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            SetDefaultButton(TextBox, Button1);
        }

        private void SetDefaultButton(TextBox txt, Button defaultButton)

        {
            txt.Attributes.Add("onkeydown", "funfordefautenterkey1(" + defaultButton.ClientID + ",event)");
        }
        protected void bversefunction(string[] arr)
        {
            string cname = arr[0];
            int cnumber = int.Parse(arr[1]);
            int vnumber = int.Parse(arr[2]);
            string mycon = "server =localhost; Uid=root; password =Chris123# ; persistsecurityinfo = True; database =tamilbible; SslMode = none";
            MySqlConnection con = new MySqlConnection(mycon);
            DataTable dt = new DataTable();
            MySqlCommand cmd = null;
            string result = null;
            try
            {
                cmd = new MySqlCommand("Select verse from bible where bookid=1 and chapternumber=1 and versenumber=1", con);
                con.Open();
                result = (string)cmd.ExecuteScalar();
                message.Text = result;
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
            string bverse = TextBox.Text;
            string[] textSplit = bverse.Split('.');
            bversefunction(textSplit);
        }
    }
}
    