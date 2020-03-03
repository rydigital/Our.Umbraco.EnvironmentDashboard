using System.Collections.Generic;
using Our.Umbraco.EnvironmentDashboard.Models;

namespace Our.Umbraco.EnvironmentDashboard
{
	public interface IGroupsBuilder
	{
		IEnumerable<Group> Build(string environment);
	}
}