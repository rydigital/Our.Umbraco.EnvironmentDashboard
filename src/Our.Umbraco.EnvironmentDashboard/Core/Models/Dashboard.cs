using Newtonsoft.Json;
using System.Collections.Generic;

namespace Our.Umbraco.EnvironmentDashboard.Core.Models
{
	public class Dashboard
	{
		public Dashboard()
		{
			Groups = new List<FactFamily>();
		}

		[JsonProperty("currentEnvironment")]
		public string CurrentEnvironment { get; set; }

		[JsonProperty("groups")]
		public List<FactFamily> Groups { get; set; }
	}
}