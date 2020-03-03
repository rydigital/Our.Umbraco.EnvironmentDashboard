using System;
using System.Collections.Generic;
using Our.Umbraco.EnvironmentDashboard.Models;

namespace Our.Umbraco.EnvironmentDashboard.Groups
{
	public class ServerInformationGroupsBuilder : IGroupsBuilder
	{
		public IEnumerable<Group> Build(string environment)
		{
			var infoGroup = new Group("Server Information");
			infoGroup.Pairs.Add(new KeyValuePair("Machine Name", Environment.MachineName));
			infoGroup.Pairs.Add(new KeyValuePair("Processor Core Count", Environment.ProcessorCount.ToString("D")));
			infoGroup.Pairs.Add(new KeyValuePair("Uptime", TimeSpan.FromMilliseconds(Environment.TickCount).ToString("c")));

			return new[] { infoGroup };
		}
	}
}