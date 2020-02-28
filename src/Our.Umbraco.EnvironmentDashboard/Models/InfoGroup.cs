using Newtonsoft.Json;
using System.Collections.Generic;

namespace Our.Umbraco.EnvironmentDashboard.Models
{
    public class InfoGroup
	{
		[JsonProperty("title")]
		public string Title { get; set; }

		[JsonProperty("pairs")]
		public List<InfoPair> Pairs { get; set; }

		public InfoGroup(string title = "Group")
		{
			Title = title;
			Pairs = new List<InfoPair>();
		}
	}
}