using Our.Umbraco.EnvironmentDashboard.Core.Providers;
using Xunit;

namespace Our.Umbraco.EnvironmentDashboard.Test
{
	public class When_Building_ServerInformationFactFamily
	{
		IFactFamilyProvider _provider;

		const string MACHINE_NAME = "Machine Name";
		const int TICK_COUNT = 100000;


		public When_Building_ServerInformationFactFamily()
		{
		}

		[Fact]
		public void Fact_Pairs_Are_Created()
		{
			// setup
			_provider = new ServerInformationFactFamilyProvider(MACHINE_NAME, TICK_COUNT);
			
			// test
			var factFamily = _provider.Build("Some Environment");

			// assert
			Assert.Equal("Server Information", factFamily.Title);
			Assert.Equal("Machine Name", factFamily.Pairs[0].Key);
			Assert.Equal(MACHINE_NAME, factFamily.Pairs[0].Value);

			Assert.Equal("Uptime", factFamily.Pairs[2].Key);
			Assert.Equal("00:01:40", factFamily.Pairs[2].Value);
		}
	}
}
