using Our.Umbraco.EnvironmentDashboard.Core.Models;

namespace Our.Umbraco.EnvironmentDashboard.Core.Providers
{
	public interface IFactFamilyProvider
	{
		FactFamily Build(string environment);
	}
}