using Application.Demo.App_Start;
using Our.Umbraco.EnvironmentDashboard.Core;
using Our.Umbraco.EnvironmentDashboard.Core.Detectors;
using Our.Umbraco.EnvironmentDashboard.Core.Providers;
using System.Configuration;
using Umbraco.Core.Composing;

namespace Application.Demo
{
	public class MyDemoComposer : IUserComposer
	{
		public void Compose(Composition composition)
		{
			string environmentFromConfig = ConfigurationManager.AppSettings["EnvironmentDashboard"];
			if (!string.IsNullOrWhiteSpace(environmentFromConfig))
			{
				// Environment can be set via the AppSetting "EnvironmentDashboard"
				composition.AddEnvironmentDashboard(new AppSettingEnvironmentDetector())
					.Append<ServerInformationFactFamilyProvider>()
					.Append<DatabaseServerFactFamilyProvider>();
			}
			else
			{
				// When the AppSetting "EnvironmentDashboard" does not exist, then domains are required for registration
				composition.AddEnvironmentDashboard(environments =>
					{
						environments
							.AddEnvironment("Local", "environmentdashboard.localhost")
							.AddEnvironment("Dev", "environmentdashboard-dev.azurewebsites.net")
							.AddEnvironment("QA", "environmentdashboard-qa.azurewebsites.net")
							.AddEnvironment("UAT", "uat-mydomain.com", "environmentdashboard-uat.azurewebsites.net")
							.AddEnvironment("Prod", "mydomain.com", "environmentdashboard-prod.azurewebsites.net");
					})
					.Append<DatabaseServerFactFamilyProvider>()
					.Append<ServerInformationFactFamilyProvider>()
					.Append<MyExampleFactFamilyProvider>();
			}
		}
	}
}