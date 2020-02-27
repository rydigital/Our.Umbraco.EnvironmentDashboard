using Umbraco.Core.Composing;
using Umbraco.Web;
using Umbraco.Web.Dashboards;

namespace Our.Umbraco.EnvironmentDashboard.Components
{
	public class RemoveDashboardComposer : IUserComposer
	{
		public void Compose(Composition composition)
		{
			//remove default startup dashboard
			composition.Dashboards().Remove<ContentDashboard>();
		}
	}
}