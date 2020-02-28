using Our.Umbraco.EnvironmentDashboard.Models;
using System.Collections.Generic;

namespace Application.Features.EnvironmentDashboard.Helpers
{
	public class EnvironmentHelper
    {
		public static string GetCurrentEnvironment(List<DomainInfo> domains, string urlAuthority)
		{
			string envName = null;
			foreach (var domain in domains)
			{
				if (domain.Url == urlAuthority)
				{
					envName = domain.Name;
					break;
				}
			}

			return envName;
		}
    }
}
