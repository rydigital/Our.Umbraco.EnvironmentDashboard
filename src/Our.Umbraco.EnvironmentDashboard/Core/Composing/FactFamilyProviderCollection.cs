using Our.Umbraco.EnvironmentDashboard.Core.Providers;
using System.Collections.Generic;
using Umbraco.Core.Composing;

namespace Our.Umbraco.EnvironmentDashboard.Core.Composing
{
	public class FactFamilyProviderCollection : BuilderCollectionBase<IFactFamilyProvider>
	{
		public FactFamilyProviderCollection(IEnumerable<IFactFamilyProvider> items) : base(items)
		{
		}
	}

	public class FactFamilyProviderCollectionBuilder : OrderedCollectionBuilderBase<FactFamilyProviderCollectionBuilder, FactFamilyProviderCollection, IFactFamilyProvider>
	{
		protected override FactFamilyProviderCollectionBuilder This => this;
	}
}