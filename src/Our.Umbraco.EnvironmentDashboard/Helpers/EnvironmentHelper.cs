using Our.Umbraco.EnvironmentDashboard.Models;
using System.Collections.Generic;

namespace Application.Features.EnvironmentDashboard.Helpers
{
	public class EnvironmentHelper
    {
		public static string GetCurrentEnvironment(List<DomainInfo> domains, string urlAuthority)
		{
			string envName = null;

			var cleanedDomain = urlAuthority
									.ToLowerInvariant()
									.Replace("http://", string.Empty)
									.Replace("https://", string.Empty)
									.Trim();

			foreach (var domain in domains)
			{
				if (domain.Url == cleanedDomain)
				{
					envName = domain.Name;
					break;
				}
			}

			return envName;
		}
    }
}
