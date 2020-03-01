using Umbraco.Core.Composing;

namespace Our.Umbraco.EnvironmentDashboard.Components
{
	public class EnvironmentDashboardGroupsCollectionBuilder : OrderedCollectionBuilderBase<EnvironmentDashboardGroupsCollectionBuilder, EnvironmentDashboardGroupsCollection, IDashboardGroupsProvider>
	{
		protected override EnvironmentDashboardGroupsCollectionBuilder This => this;
	}
}