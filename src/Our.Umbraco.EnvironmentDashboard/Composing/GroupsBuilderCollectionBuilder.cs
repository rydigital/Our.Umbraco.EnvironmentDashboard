using Umbraco.Core.Composing;

namespace Our.Umbraco.EnvironmentDashboard.Composing
{
	public class GroupsBuilderCollectionBuilder : OrderedCollectionBuilderBase<GroupsBuilderCollectionBuilder, GroupsBuilderCollection, IGroupsBuilder>
	{
		protected override GroupsBuilderCollectionBuilder This => this;
	}
}