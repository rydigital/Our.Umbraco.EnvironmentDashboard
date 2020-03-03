using Newtonsoft.Json;

namespace Our.Umbraco.EnvironmentDashboard.Core.Models
{
    public class Fact
	{
		[JsonProperty("key")]
		public string Key { get; set; }

		[JsonProperty("value")]
		public string Value { get; set; }

		public Fact(string key, string value)
		{
			Key = key;
			Value = value;
		}
	}
}