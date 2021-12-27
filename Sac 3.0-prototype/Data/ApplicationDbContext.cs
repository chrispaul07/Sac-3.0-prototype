using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MySql.Data.MySqlClient;

namespace Sac_3._0_prototype.Data
{
    public class ApplicationDbContext
    {
        string mycon = "server =localhost; Uid=root; password =Chris123# ; persistsecurityinfo = True; database =tamilsong; SslMode = none";
        MySqlConnection con = new MySqlConnection();
        DataTable dt = new DataTable();
        MySqlCommand cmd = null;
        string result = null;
    }
}