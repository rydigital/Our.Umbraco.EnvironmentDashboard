using System.Collections.Generic;
using System.Web;
using Our.Umbraco.EnvironmentDashboard.Helpers;
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
				objects.Add("deploy", new Dictionary<string, object>
				{
					{ "CurrentWorkspace", EnvironmentHelper.GetCurrentEnvironmentFromString(HttpContext.Current.Request.Url.AbsoluteUri).ToString() }
				});
			};
		}
	}
}