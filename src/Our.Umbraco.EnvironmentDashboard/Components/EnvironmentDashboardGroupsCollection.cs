using System.Collections.Generic;
using Umbraco.Core.Composing;

namespace Our.Umbraco.EnvironmentDashboard.Components
{
	public class EnvironmentDashboardGroupsCollection : BuilderCollectionBase<IDashboardGroupsProvider>
	{
		public EnvironmentDashboardGroupsCollection(IEnumerable<IDashboardGroupsProvider> items) : base(items)
		{
		}
	}
}