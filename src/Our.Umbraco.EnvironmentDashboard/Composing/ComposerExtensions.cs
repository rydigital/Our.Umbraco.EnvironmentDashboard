using System;
using Our.Umbraco.EnvironmentDashboard.Components;
using Our.Umbraco.EnvironmentDashboard.Detectors;
using Our.Umbraco.EnvironmentDashboard.Groups;
using Umbraco.Core;
using Umbraco.Core.Composing;
using Umbraco.Web;

namespace Our.Umbraco.EnvironmentDashboard.Composing
{
	public static class ComposerExtensions
	{
		public static GroupsBuilderCollectionBuilder AddEnvironmentDashboard(this Composition composition,
			Action<IDomainEnvironmentBuilder> builder)
		{
			if (composition == null)
				throw new ArgumentNullException(nameof(composition));

			if (builder == null)
				throw new ArgumentNullException(nameof(builder));

			var domainEnvironmentBuilder = new DomainEnvironmentBuilder();

			builder(domainEnvironmentBuilder);

			composition.RegisterUnique<IEnvironmentDetector>(factory => new DomainEnvironmentDetector((IHttpContextAccessor)factory.GetInstance(typeof(IHttpContextAccessor)), domainEnvironmentBuilder.GetDomainEnvironments()));
			composition.Components().Append<BackofficeBrowserTitleComponent>();

			return composition.AddEnvironmentDashboardGroups();
		}

		public static GroupsBuilderCollectionBuilder AddEnvironmentDashboard(this Composition composition)
		{
			composition.RegisterUnique<IEnvironmentDetector, AppSettingsEnvironmentDetector>();
			composition.Components().Append<BackofficeBrowserTitleComponent>();

			return composition.AddEnvironmentDashboardGroups();
		}

		public static GroupsBuilderCollectionBuilder AddEnvironmentDashboard(this Composition composition, IEnvironmentDetector environmentDetector)
		{
			if(environmentDetector == null)
				throw new ArgumentNullException(nameof(environmentDetector));

			composition.RegisterUnique<IEnvironmentDetector>(environmentDetector);
			composition.Components().Append<BackofficeBrowserTitleComponent>();

			return composition.AddEnvironmentDashboardGroups();
		}

		public static GroupsBuilderCollectionBuilder AddEnvironmentDashboard<TDashboardEnvironmentProvider>(this Composition composition) where TDashboardEnvironmentProvider: IEnvironmentDetector
		{
			composition.RegisterUnique<IEnvironmentDetector, TDashboardEnvironmentProvider>();
			composition.Components().Append<BackofficeBrowserTitleComponent>();

			return composition.AddEnvironmentDashboardGroups();
		}

		public static GroupsBuilderCollectionBuilder AddEnvironmentDashboardGroups(this global::Umbraco.Core.Composing.Composition composition)
		{
			return composition.WithCollectionBuilder<GroupsBuilderCollectionBuilder>();
		}

		public static GroupsBuilderCollectionBuilder AddDatabaseServerGroup(
			this GroupsBuilderCollectionBuilder builder)
		{
			builder.Append<DatabaseServerGroupsBuilder>();
			return builder;
		}

		public static GroupsBuilderCollectionBuilder AddServerInformationGroup(
			this GroupsBuilderCollectionBuilder builder)
		{
			builder.Append<ServerInformationGroupsBuilder>();
			return builder;
		}
	}


}