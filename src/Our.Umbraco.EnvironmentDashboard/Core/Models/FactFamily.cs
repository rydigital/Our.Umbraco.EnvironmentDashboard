using Newtonsoft.Json;
using System.Collections.Generic;

namespace Our.Umbraco.EnvironmentDashboard.Core.Models
{
    public class FactFamily
	{
		[JsonProperty("title")]
		public string Title { get; set; }

		[JsonProperty("pairs")]
		public List<Fact> Pairs { get; set; }

		public FactFamily(string title = "Group")
		{
			Title = title;
			Pairs = new List<Fact>();
		}
	}
}