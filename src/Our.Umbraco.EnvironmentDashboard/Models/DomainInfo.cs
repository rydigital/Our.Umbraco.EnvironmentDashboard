using Newtonsoft.Json;

namespace Our.Umbraco.EnvironmentDashboard.Models
{
	public class DomainInfo
	{
		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("url")]
		public string Url { get; set; }

		public DomainInfo(string name, string url)
		{
			Name = name;
			Url = url;
		}
	}
}