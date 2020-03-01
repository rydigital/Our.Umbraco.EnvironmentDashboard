using System;
using System.Collections.Generic;
using Our.Umbraco.EnvironmentDashboard.Composing;
using Umbraco.Core;
using Umbraco.Core.Composing;
using Umbraco.Web;

namespace Our.Umbraco.EnvironmentDashboard.Components
{
	public static class EnvironmentDashboardComposerExtensions
	{
		public static EnvironmentDashboardGroupsCollectionBuilder AddEnvironmentDashboard(this Composition composition, IDictionary<DashboardEnvironment, IEnumerable<string>> environments)
		{
			composition.RegisterUnique<IDashboardEnvironmentProvider>(factory => new DashboardEnvironmentProvider((IHttpContextAccessor)factory.GetInstance(typeof(IHttpContextAccessor)), environments));
			composition.Components().Append<EnvironmentDashboardComponent>();
			composition.Components().Append<BackofficeBrowserTitleComponent>();

			return composition.AddEnvironmentDashboardGroups();
		}


		public static EnvironmentDashboardGroupsCollectionBuilder AddEnvironmentDashboard(this Composition composition, IDashboardEnvironmentProvider environmentProvider)
		{
			if(environmentProvider == null)
				throw new ArgumentNullException(nameof(environmentProvider));

			composition.RegisterUnique<IDashboardEnvironmentProvider>(environmentProvider);
			composition.Components().Append<EnvironmentDashboardComponent>();
			composition.Components().Append<BackofficeBrowserTitleComponent>();

			return composition.AddEnvironmentDashboardGroups();
		}

		public static EnvironmentDashboardGroupsCollectionBuilder AddEnvironmentDashboard<TDashboardEnvironmentProvider>(this Composition composition) where TDashboardEnvironmentProvider: IDashboardEnvironmentProvider
		{
			composition.RegisterUnique<IDashboardEnvironmentProvider, TDashboardEnvironmentProvider>();
			composition.Components().Append<EnvironmentDashboardComponent>();
			composition.Components().Append<BackofficeBrowserTitleComponent>();

			return composition.AddEnvironmentDashboardGroups();
		}

		public static EnvironmentDashboardGroupsCollectionBuilder AddEnvironmentDashboardGroups(this global::Umbraco.Core.Composing.Composition composition)
		{
			return composition.WithCollectionBuilder<EnvironmentDashboardGroupsCollectionBuilder>();
		}
	}
}