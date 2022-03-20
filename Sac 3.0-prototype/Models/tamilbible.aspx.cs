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
        readonly String dbName = "tamilbible";
        readonly String titleTable = "books";
        readonly String contentTable = "bible";
        static string cname;
        static int cnumber=0,vnumber=0;

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
                cname = arr[0];
                MySqlConnection con;
                MySqlCommand cmd = null;
                MySqlCommand currentbookid = null;
                MySqlCommand currentchapter = null;
                MySqlCommand currentverse = null;
                string result = null;
                MySqlCommand cmdd = null;
                string result1 = null;
                int bnumber = 0;
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
                    string query = "Select bookid from "+ titleTable + " where bookshortname ='" + cname + "'";
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
                    string query2 = "Select chapternumber from "+ contentTable +" where bookid=" + bnumber + " and chapternumber =" + arr[1] + " and versenumber=1";
                    currentchapter = new MySqlCommand(query2, con);
                    Object obj2 = currentchapter.ExecuteScalar();
                    if (obj2 != null)
                    {
                        cnumber = int.Parse(arr[1]);
                    }
                    else
                    {
                        throw (new Exception("Chapter not found : " + arr[1]));
                    }
                    string query3 = "Select versenumber from " + contentTable + " where bookid=" + bnumber + " and chapternumber =" + cnumber + " and versenumber=" + arr[2];
                    currentverse = new MySqlCommand(query3, con);
                    Object obj3 = currentverse.ExecuteScalar();
                    if (obj3 != null)
                    {
                        vnumber = int.Parse(arr[2]);
                    }
                    else
                    {
                        throw (new Exception("Verse not found : " + arr[2]));
                    }
                    string query1 = "Select verse from " + contentTable + " where bookid="+ bnumber + " and chapternumber=" + cnumber + " and versenumber=" + vnumber;
                    cmd = new MySqlCommand("Select bookname from " + titleTable + " where bookid="+ bnumber, con);
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
        protected void Next_Verse(object sender, EventArgs e)
        {
            vnumber += 1; 
            string[] textSplit = { cname, cnumber.ToString(), vnumber.ToString() };
            Bversefunction(textSplit);
        }
        protected void Prev_Verse(object sender, EventArgs e)
        {
            try
            {
                vnumber -= 1;
                if (vnumber <= 0)
                {
                    vnumber = 1;
                    throw (new Exception("Verse not found : "));
                }
                string[] textSplit = { cname, cnumber.ToString(), vnumber.ToString() };
                Bversefunction(textSplit);
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }
        protected void Next_Chapter(object sender, EventArgs e)
        {
            cnumber += 1;
            string[] textSplit = { cname, cnumber.ToString(), vnumber.ToString() };
            Bversefunction(textSplit);
        }
        protected void Prev_Chapter(object sender, EventArgs e)
        {
            try
            {
                cnumber -= 1;
                if (cnumber <= 0)
                {
                    cnumber = 1;
                    throw (new Exception("Chapter not found : "));
                }
                string[] textSplit = { cname, cnumber.ToString(), vnumber.ToString() };
                Bversefunction(textSplit);
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }
        }


    }
}
    