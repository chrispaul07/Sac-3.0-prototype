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
    public partial class WebForm1 : System.Web.UI.Page
    {

        protected void retrieve_Click(object sender, EventArgs e)
        {
            string mycon = "server =localhost; Uid=root; password =Chris123# ; persistsecurityinfo = True; database =tamilsong; SslMode = none";
            MySqlConnection con = new MySqlConnection(mycon);
            DataTable dt = new DataTable();
            MySqlCommand cmd = null;
            string result = null;
            try
            {
                cmd = new MySqlCommand("Select para from song where songnumber=2 and stanzanumber=1", con);
                con.Open();
                result = (string)cmd.ExecuteScalar();
                var outputHtml = result.Replace("\r\n", "<br />").Replace("\n", "<br />").Replace("\r", "<br />");
                con.Close();
                Vassign(outputHtml);
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
                con.Close();
            }
        }
        protected string variable;
        public void Vassign(string a)
        {
            variable = a;
        }
}
}