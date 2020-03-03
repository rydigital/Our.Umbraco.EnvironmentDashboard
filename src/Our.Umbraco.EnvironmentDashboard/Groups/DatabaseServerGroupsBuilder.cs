using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using Our.Umbraco.EnvironmentDashboard.Models;

namespace Our.Umbraco.EnvironmentDashboard.Groups
{
	public class DatabaseServerGroupsBuilder : IGroupsBuilder
	{
		public IEnumerable<Group> Build(string environment)
		{
			var infoGroup = new Group("Database Settings");
			var connectionString = ConfigurationManager.ConnectionStrings["umbracoDbDSN"].ConnectionString;

			if (connectionString.Contains(".sdf"))
			{
				infoGroup.Pairs.Add(new KeyValuePair("SQL CE", connectionString));
			}
			else
			{
				var datbaseServer = new SqlConnectionStringBuilder(connectionString).DataSource;
				var databaseName = new SqlConnectionStringBuilder(connectionString).InitialCatalog;
				infoGroup.Pairs.Add(new KeyValuePair("Server", datbaseServer));
				infoGroup.Pairs.Add(new KeyValuePair("Database Name", databaseName));
			}

			return new []{ infoGroup };
		}
	}
}