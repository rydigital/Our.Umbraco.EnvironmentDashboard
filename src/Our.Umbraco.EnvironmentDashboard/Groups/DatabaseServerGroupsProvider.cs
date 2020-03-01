using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using Our.Umbraco.EnvironmentDashboard.Models;

namespace Our.Umbraco.EnvironmentDashboard.Groups
{
	public class DatabaseServerGroupsProvider : IDashboardGroupsProvider
	{
		public IEnumerable<InfoGroup> GetGroups(DashboardEnvironment environment)
		{
			var infoGroup = new InfoGroup("Database Settings");
			var connectionString = ConfigurationManager.ConnectionStrings["umbracoDbDSN"].ConnectionString;

			if (connectionString.Contains(".sdf"))
			{
				infoGroup.Pairs.Add(new InfoPair("SQL CE", connectionString));
			}
			else
			{
				var datbaseServer = new SqlConnectionStringBuilder(connectionString).DataSource;
				var databaseName = new SqlConnectionStringBuilder(connectionString).InitialCatalog;
				infoGroup.Pairs.Add(new InfoPair("Server", datbaseServer));
				infoGroup.Pairs.Add(new InfoPair("Database Name", databaseName));
			}

			return new []{ infoGroup };
		}
	}

	public class UptimeDashboardGroupsProvider : IDashboardGroupsProvider
	{
		public IEnumerable<InfoGroup> GetGroups(DashboardEnvironment environment)
		{
			var infoGroup = new InfoGroup("Server Information");
			infoGroup.Pairs.Add(new InfoPair("Machine Name", Environment.MachineName));
			infoGroup.Pairs.Add(new InfoPair("Processor Core Count", Environment.ProcessorCount.ToString("D")));
			infoGroup.Pairs.Add(new InfoPair("Uptime", TimeSpan.FromMilliseconds(Environment.TickCount).ToString("c")));

			return new[] { infoGroup };
		}
	}
}