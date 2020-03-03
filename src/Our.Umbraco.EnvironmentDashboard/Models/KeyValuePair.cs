using Newtonsoft.Json;

namespace Our.Umbraco.EnvironmentDashboard.Models
{
    public class KeyValuePair
	{
		[JsonProperty("key")]
		public string Key { get; set; }

		[JsonProperty("value")]
		public string Value { get; set; }

		public KeyValuePair(string key, string value)
		{
			Key = key;
			Value = value;
		}
	}
}