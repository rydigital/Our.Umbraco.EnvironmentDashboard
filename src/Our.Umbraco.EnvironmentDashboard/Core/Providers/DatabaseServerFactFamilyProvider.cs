using System.Configuration;
using System.Data.SqlClient;
using Our.Umbraco.EnvironmentDashboard.Core.Models;

namespace Our.Umbraco.EnvironmentDashboard.Core.Providers
{
	public class DatabaseServerFactFamilyProvider : IFactFamilyProvider
	{
		private readonly ConnectionStringSettings _connectionString;

		public DatabaseServerFactFamilyProvider(ConnectionStringSettings settings)
		{
			_connectionString = settings;
		}

		public DatabaseServerFactFamilyProvider() : this(ConfigurationManager.ConnectionStrings["umbracoDbDSN"])
		{ }

		public FactFamily Build(string environment)
		{
			var factFamily = new FactFamily("Database Settings");
			
			if (_connectionString.ProviderName.Contains("System.Data.SqlServerCe"))
			{
				factFamily.Pairs.Add(new Fact("SqlServerCe", _connectionString.ConnectionString));
			}
			else
			{
				var datbaseServer = new SqlConnectionStringBuilder(_connectionString.ConnectionString).DataSource;
				var databaseName = new SqlConnectionStringBuilder(_connectionString.ConnectionString).InitialCatalog;
				factFamily.Pairs.Add(new Fact("Server", datbaseServer));
				factFamily.Pairs.Add(new Fact("Database", databaseName));
			}

			return factFamily;
		}
	}
}