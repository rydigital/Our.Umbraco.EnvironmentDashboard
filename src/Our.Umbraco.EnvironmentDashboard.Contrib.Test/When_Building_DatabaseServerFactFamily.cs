using Our.Umbraco.EnvironmentDashboard.Core.Providers;
using System.Configuration;
using Xunit;

namespace Our.Umbraco.EnvironmentDashboard.Test
{
	public class When_Building_DatabaseServerFactFamily
    {
		IFactFamilyProvider _provider;

		public When_Building_DatabaseServerFactFamily()
		{
		}

		[Fact]
		public void SqlCE_ConnectionString_Is_Parsed()
		{
			// setup
			var setting = new ConnectionStringSettings("umbracoDbDSN", "Data Source=|DataDirectory|\\Umbraco.sdf;Flush Interval=1;", "System.Data.SqlServerCe.4.0");
			_provider = new DatabaseServerFactFamilyProvider(setting);
			
			// test
			var factFamily = _provider.Build("Some Environment");

			// assert
			Assert.Equal("Database Settings", factFamily.Title);
			Assert.Equal("SqlServerCe", factFamily.Pairs[0].Key);
			Assert.Equal("Data Source=|DataDirectory|\\Umbraco.sdf;Flush Interval=1;", factFamily.Pairs[0].Value);
		}


		[Fact]
		public void SqlServer_ConnectionString_Is_Parsed()
		{
			// setup
			var setting = new ConnectionStringSettings("umbracoDbDSN", "server=ServerAddress;database=DatabaseName;user id=UserId;password='xxx'", "System.Data.SqlClient");
			_provider = new DatabaseServerFactFamilyProvider(setting);

			// test
			var factFamily = _provider.Build("Some Environment");

			// assert
			Assert.Equal("Database Settings", factFamily.Title);
			Assert.Equal("Server", factFamily.Pairs[0].Key);
			Assert.Equal("ServerAddress", factFamily.Pairs[0].Value);
			Assert.Equal("Database", factFamily.Pairs[1].Key);
			Assert.Equal("DatabaseName", factFamily.Pairs[1].Value);
		}
	}
}
