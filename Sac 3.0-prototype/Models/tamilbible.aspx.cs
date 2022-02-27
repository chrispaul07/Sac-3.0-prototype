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
                string mycon = "server =localhost; Uid=root; password =Chris123# ; persistsecurityinfo = True; database =tamilbible; SslMode = none";
                MySqlConnection con = new MySqlConnection(mycon);
                MySqlCommand cmd = null;
                MySqlCommand currentbookid = null;
                string result = null;
                MySqlCommand cmdd = null;
                string result1 = null;
                int bnumber = 0;
                try
                {
                    con.Open();
                    string query = "Select bookid from books where bookshortname ='" + cname + "'";
                    currentbookid = new MySqlCommand(query,con);
                    Object obj = currentbookid.ExecuteScalar();
                    if (obj != null)
                    {
                        bnumber = Convert.ToInt32(obj.ToString());
                    }
                    else
                    {
                        throw (new Exception("Book not found : "+ cname));
                    }
                    
                    string query1 = "Select verse from bible where bookid="+ bnumber + " and chapternumber=" + cnumber + " and versenumber=" + vnumber;
                    cmd = new MySqlCommand("Select bookname from books where bookid="+ bnumber, con);
                    cmdd = new MySqlCommand(query1, con);
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
    