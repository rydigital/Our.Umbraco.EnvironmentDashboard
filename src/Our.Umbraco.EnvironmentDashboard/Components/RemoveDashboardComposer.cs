using Umbraco.Core.Composing;
using Umbraco.Web;
using Umbraco.Web.Dashboards;

namespace Application.Features.EnvironmentDashboard.Components
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