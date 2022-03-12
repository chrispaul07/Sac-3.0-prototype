using System;
using System.Configuration;

namespace Sac_3._0_prototype.Models
{
	public class SQLServerSettings
	{
		public SQLServerSettings()
		{ }
		public static String GetConnectionString(String dbName)
		{
			String serverName = ConfigurationManager.AppSettings["host"];
			String userName = ConfigurationManager.AppSettings["userid"];
			String password = ConfigurationManager.AppSettings["password"];
			String connectionString = "server =" + serverName + 
				"; Uid=" + userName +"; password =" + password + " ; persistsecurityinfo = True; database =" + dbName + "; SslMode = none";
			return connectionString;
		}



	}
}