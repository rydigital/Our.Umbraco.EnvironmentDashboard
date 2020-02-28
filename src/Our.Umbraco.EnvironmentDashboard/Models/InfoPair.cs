using Newtonsoft.Json;

namespace Our.Umbraco.EnvironmentDashboard.Models
{
    public class InfoPair
	{
		[JsonProperty("key")]
		public string Key { get; set; }

		[JsonProperty("value")]
		public string Value { get; set; }

		public InfoPair(string key, string value)
		{
			Key = key;
			Value = value;
		}
	}
}