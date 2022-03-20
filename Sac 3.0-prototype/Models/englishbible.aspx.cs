using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Threading.Tasks;
using MySqlConnector;

namespace Sac_3._0_prototype.Models
{
    public partial class englishbible : System.Web.UI.Page
    {
        readonly String dbName = "englishbible";
        readonly String titleTable = "books";
        readonly String contentTable = "bible";
        static string cname;
        static int cnumber = 0, vnumber = 0;

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
                MySqlCommand bookname = null;
                MySqlCommand currentbookid = null;
                MySqlCommand currentchapter = null;
                MySqlCommand currentverse = null;
                string result = null;
                MySqlCommand bibleverse = null;
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
                    string bookidquery = "Select bookid from " + titleTable + " where bookshortname ='" + cname + "'";
                    currentbookid = new MySqlCommand(bookidquery, con);
                    Object bookidobject = currentbookid.ExecuteScalar();
                    if (bookidobject != null)
                    {
                        bnumber = Convert.ToInt32(bookidobject.ToString());
                    }
                    else
                    {
                        throw (new Exception("Book not found : " + cname));
                    }
                    string chapterquery = "Select chapternumber from " + contentTable + " where bookid=" + bnumber + " and chapternumber =" + arr[1] + " and versenumber=1";
                    currentchapter = new MySqlCommand(chapterquery, con);
                    Object chapterobject = currentchapter.ExecuteScalar();
                    if (chapterobject != null)
                    {
                        cnumber = int.Parse(arr[1]);
                    }
                    else
                    {
                        throw (new Exception("Chapter not found : " + arr[1]));
                    }
                    string versequery = "Select versenumber from " + contentTable + " where bookid=" + bnumber + " and chapternumber =" + cnumber + " and versenumber=" + arr[2];
                    currentverse = new MySqlCommand(versequery, con);
                    Object verseobject = currentverse.ExecuteScalar();
                    if (verseobject != null)
                    {
                        vnumber = int.Parse(arr[2]);
                    }
                    else
                    {
                        throw (new Exception("Verse not found : " + arr[2]));
                    }
                    string booknamequery = "Select bookname from " + titleTable + " where bookid=" + bnumber;
                    bookname = new MySqlCommand(booknamequery, con);
                    object booknameobject = bookname.ExecuteScalar();
                    string versecontentquery = "Select verse from " + contentTable + " where bookid=" + bnumber + " and chapternumber=" + cnumber + " and versenumber=" + vnumber;
                    bibleverse = new MySqlCommand(versecontentquery, con);
                    object bibleverseobject = bibleverse.ExecuteScalar();
                    result = booknameobject.ToString();
                    result1 = bibleverseobject.ToString();
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
