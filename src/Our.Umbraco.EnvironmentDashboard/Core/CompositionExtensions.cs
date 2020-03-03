using System;
using Our.Umbraco.EnvironmentDashboard.Core.Components;
using Our.Umbraco.EnvironmentDashboard.Core.Composing;
using Our.Umbraco.EnvironmentDashboard.Core.Detectors;
using Umbraco.Core;
using Umbraco.Core.Composing;
using Umbraco.Web;

namespace Our.Umbraco.EnvironmentDashboard.Core
{
	public static class CompositionExtensions
	{
		public static FactFamilyProviderCollectionBuilder AddEnvironmentDashboard(this Composition composition, Action<IEnvironmentContainer> builder)
		{
			var domainEnvironmentBuilder = new EnvironmentContainer();
			builder(domainEnvironmentBuilder);

			var registeredEnvironments = domainEnvironmentBuilder.GetEnvironments();
			composition.RegisterUnique<IEnvironmentDetector>(factory => new DomainEnvironmentDetector((IHttpContextAccessor)factory.GetInstance(typeof(IHttpContextAccessor)), registeredEnvironments)); ;
			composition.Components().Append<BackofficeBrowserTitleComponent>();

			return composition.WithCollectionBuilder<FactFamilyProviderCollectionBuilder>();
		}



		// These are currently not used. Unsure if we should keep them.

		public static FactFamilyProviderCollectionBuilder AddEnvironmentDashboard(this Composition composition, IEnvironmentDetector environmentDetector)
		{
			composition.RegisterUnique<IEnvironmentDetector>(environmentDetector);
			composition.Components().Append<BackofficeBrowserTitleComponent>();

			return composition.WithCollectionBuilder<FactFamilyProviderCollectionBuilder>();
		}

		public static FactFamilyProviderCollectionBuilder AddEnvironmentDashboard<TDashboardEnvironmentDetector>(this Composition composition) where TDashboardEnvironmentDetector : IEnvironmentDetector
		{
			composition.RegisterUnique<IEnvironmentDetector, TDashboardEnvironmentDetector>();
			composition.Components().Append<BackofficeBrowserTitleComponent>();

			return composition.WithCollectionBuilder<FactFamilyProviderCollectionBuilder>();
		}
	}
}