using System.Collections.Generic;
using Umbraco.Core.Composing;

namespace Our.Umbraco.EnvironmentDashboard.Composing
{
	public class GroupsBuilderCollection : BuilderCollectionBase<IGroupsBuilder>
	{
		public GroupsBuilderCollection(IEnumerable<IGroupsBuilder> items) : base(items)
		{
		}
	}
}