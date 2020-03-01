using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Our.Umbraco.EnvironmentDashboard.Helpers;

namespace Our.Umbraco.EnvironmentDashboard.Models
{
	public class EnvironmentInfo
	{
		private static readonly Lazy<EnvironmentInfo>
			lazy =
			new Lazy<EnvironmentInfo>
				(() => new EnvironmentInfo());

		public static EnvironmentInfo Instance { get { return lazy.Value; } }

		public EnvironmentInfo()
		{
			Groups = new List<InfoGroup>();
			Domains = new List<DomainInfo>();
		}

		internal void SetCurrentEnvironment(string urlAuthority)
		{
			CurrentEnvironment = EnvironmentHelper.GetCurrentEnvironment(Domains, urlAuthority);

			if (string.IsNullOrWhiteSpace(CurrentEnvironment))
			{
				CurrentEnvironment = "Could not match current backoffice domain to any registered domain.";
			}
		}

		[JsonProperty("environments")]
		public List<DomainInfo> Domains { get; set; }

		[JsonProperty("currentEnvironment")]
		public string CurrentEnvironment { get; set; }

		[JsonProperty("groups")]
		public List<InfoGroup> Groups { get; set; }
	}
}