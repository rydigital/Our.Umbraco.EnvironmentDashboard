using Our.Umbraco.EnvironmentDashboard.Models;
using System.Configuration;
using System.Data.SqlClient;
using Umbraco.Core;
using Umbraco.Core.Composing;

namespace Our.Umbraco.EnvironmentDashboard.Components
{
	public class EnvironmentDashboardComposer : IUserComposer
	{
		public void Compose(Composition composition)
		{
			composition.Components().Insert<EnvironmentDashboardComponent>();
		}
	}

	public class EnvironmentDashboardComponent : IComponent
	{
		public void Initialize()
		{
			var infoGroup = GetDatabaseServerConfig();
			EnvironmentInfo.Instance.Groups.Add(infoGroup);
		}

		public void Terminate()
		{
		}

		private static InfoGroup GetDatabaseServerConfig()
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

			return infoGroup;
		}
	}
}