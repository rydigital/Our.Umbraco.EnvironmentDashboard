using Our.Umbraco.EnvironmentDashboard.Composing;
using Umbraco.Core.Composing;

namespace Application.Demo
{
	public class MyDemoComposer : IUserComposer
	{
		public void Compose(Composition composition)
		{
			composition.AddEnvironmentDashboard(environments =>
				{
					environments
						.AddEnvironment("Local", "localhost:21801")
						.AddEnvironment("Development", "environmentdashboard-dev.ry.com")
						.AddEnvironment("QA", "environmentdashboard-qa.ry.com")
						.AddEnvironment("UAT", "environmentdashboard-uat.ry.com");
				})
				.AddServerInformationGroup()
				.AddDatabaseServerGroup();
		}
	}
}