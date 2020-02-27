using System;
using System.Collections.Generic;

namespace Our.Umbraco.EnvironmentDashboard.Attributes
{
	public class EnvironmentMatchAttribute : Attribute
	{
		/// <param name="matches">Comma seperated list of matches for this environment</param>
		public EnvironmentMatchAttribute(string matches)
		{
			this.MatchValues = matches.Split(new[] {","}, StringSplitOptions.RemoveEmptyEntries);
		}

		public IEnumerable<string> MatchValues { get; set; }
	}
}