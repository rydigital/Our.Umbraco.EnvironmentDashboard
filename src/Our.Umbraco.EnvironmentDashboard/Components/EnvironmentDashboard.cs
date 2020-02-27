using Umbraco.Core.Composing;
using Umbraco.Core.Dashboards;

namespace Our.Umbraco.EnvironmentDashboard.Components
{
	[Weight(10)]
	public class EnvironmentDashboard : IDashboard
	{
		public string Alias => "environmentDashboard";
		public string View => "/App_Plugins/Our.Umbraco.EnvironmentDashboard/backoffice/app.view.html";
		public string[] Sections => new[] {"content"};

		public IAccessRule[] AccessRules => new IAccessRule[]
		{
			new AccessRule {Type = AccessRuleType.Deny, Value = Umbraco.Core.Constants.Security.TranslatorGroupAlias},
			new AccessRule {Type = AccessRuleType.Grant, Value = Umbraco.Core.Constants.Security.AdminGroupAlias}
		};
	}
}