using System.Collections.Generic;
using Our.Umbraco.EnvironmentDashboard.Models;

namespace Our.Umbraco.EnvironmentDashboard
{
	public interface IDashboardGroupsProvider
	{
		IEnumerable<InfoGroup> GetGroups(DashboardEnvironment environment);
	}
}