using Application.Features.EnvironmentDashboard.Helpers;
using Our.Umbraco.EnvironmentDashboard.Models;
using System.Collections.Generic;
using System.Web;
using Umbraco.Core.Composing;
using Umbraco.Web.JavaScript;

namespace Our.Umbraco.EnvironmentDashboard.Components
{
	public class ServerVariablesComposer : IUserComposer
	{
		public void Compose(Composition composition)
		{
			ServerVariablesParser.Parsing += (sender, objects) =>
			{
				//this will inject the environment into the brower title
				//which will show in the browser tab
				//eg "(Local) Content - website.local"

				var environmentName = EnvironmentHelper.GetCurrentEnvironment(EnvironmentInfo.Instance.Domains, HttpContext.Current.Request.Url.Authority);

				if (string.IsNullOrWhiteSpace(environmentName))
				{
					environmentName = "Error";
				}

				objects.Add("deploy", new Dictionary<string, object>
				{
					{ "CurrentWorkspace",  environmentName }
				});
			};
		}
	}
}