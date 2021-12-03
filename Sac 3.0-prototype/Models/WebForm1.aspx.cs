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
            string mycon = "server =localhost; Uid=root; password =Chris123# ; persistsecurityinfo = True; database =englishsong; SslMode = none";
            MySqlConnection con = new MySqlConnection(mycon);
            DataTable dt = new DataTable();
            MySqlCommand cmd = null;
            try
            {
                cmd = new MySqlCommand("Select para from song where songnumber=1 and stanzanumber=1 ", con);
                con.Open();
                dt.Load(cmd.ExecuteReader());  
                con.Close();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "')</script>");
                con.Close();
            }
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
    }
}