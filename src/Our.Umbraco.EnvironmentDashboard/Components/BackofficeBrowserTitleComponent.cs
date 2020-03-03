using System.Collections.Generic;
using Umbraco.Core.Composing;
using Umbraco.Web.JavaScript;

namespace Our.Umbraco.EnvironmentDashboard.Components
{
	public class BackofficeBrowserTitleComponent : IComponent
	{
		private readonly IEnvironmentDetector _environmentDetector;

		public BackofficeBrowserTitleComponent(IEnvironmentDetector environmentDetector)
		{
			this._environmentDetector = environmentDetector;
		}

		public void Initialize()
		{
			ServerVariablesParser.Parsing += (sender, objects) =>
			{
				//this will inject the environment into the browser title
				//which will show in the browser tab
				//eg "(Local) Content - website.local"

				var environment = this._environmentDetector.Detect();

				objects.Add("deploy", new Dictionary<string, object>
				{
					{ "CurrentWorkspace",  environment }
				});
			};
		}

		public void Terminate() {}
	}
}