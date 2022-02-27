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
                string mycon = "server =localhost; Uid=root; password =Chris123# ; persistsecurityinfo = True; database =englishbible; SslMode = none";
                MySqlConnection con = new MySqlConnection(mycon);
                MySqlCommand cmd = null;
                string result = null;
                MySqlCommand cmdd = null;
                string result1 = null;
                try
                {
                    string query1 = "Select verse from bible where bookid=1 and chapternumber='" + cnumber + "'and versenumber='" + vnumber + "'";
                    cmd = new MySqlCommand("Select bookname from books where bookid=1", con);
                    cmdd = new MySqlCommand(query1, con);
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
            { }

        }

        protected void ButtonIN_Click(object sender, EventArgs e)
        {
            string bverse = TextBox.Text;
            string[] textSplit = bverse.Split('.');
            Bversefunction(textSplit);
        }
    }
}


namespace AzureMySqlExample
{
    class MySqlRead
    {
        static async Task Main(string[] args)
        {
            var builder = new MySqlConnectionStringBuilder
            {
                Server = "YOUR-SERVER.mysql.database.azure.com",
                Database = "YOUR-DATABASE",
                UserID = "USER@YOUR-SERVER",
                Password = "PASSWORD",
                SslMode = MySqlSslMode.Required,
            };

            using (var conn = new MySqlConnection(builder.ConnectionString))
            {
                Console.WriteLine("Opening connection");
                await conn.OpenAsync();

                using (var command = conn.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM inventory;";

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            Console.WriteLine(string.Format(
                                "Reading from table=({0}, {1}, {2})",
                                reader.GetInt32(0),
                                reader.GetString(1),
                                reader.GetInt32(2)));
                        }
                    }
                }

                Console.WriteLine("Closing connection");
            }

            Console.WriteLine("Press RETURN to exit");
            Console.ReadLine();
        }
    }
}