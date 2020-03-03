using Newtonsoft.Json;
using System.Collections.Generic;

namespace Our.Umbraco.EnvironmentDashboard.Models
{
    public class Group
	{
		[JsonProperty("title")]
		public string Title { get; set; }

		[JsonProperty("pairs")]
		public List<KeyValuePair> Pairs { get; set; }

		public Group(string title = "Group")
		{
			Title = title;
			Pairs = new List<KeyValuePair>();
		}
	}
}