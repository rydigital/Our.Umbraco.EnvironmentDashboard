using System.Collections.Generic;
using Umbraco.Core.Composing;
using Umbraco.Web.JavaScript;

namespace Our.Umbraco.EnvironmentDashboard.Composing
{
	public class BackofficeBrowserTitleComponent : IComponent
	{
		private readonly IDashboardEnvironmentProvider _dashboardEnvironmentProvider;

		public BackofficeBrowserTitleComponent(IDashboardEnvironmentProvider dashboardEnvironmentProvider)
		{
			_dashboardEnvironmentProvider = dashboardEnvironmentProvider;
		}

		public void Initialize()
		{
			ServerVariablesParser.Parsing += (sender, objects) =>
			{
				//this will inject the environment into the browser title
				//which will show in the browser tab
				//eg "(Local) Content - website.local"

				var environment = _dashboardEnvironmentProvider.GetEnvironment();

				objects.Add("deploy", new Dictionary<string, object>
				{
					{ "CurrentWorkspace",  environment.Name }
				});
			};
		}

		public void Terminate() {}
	}
}