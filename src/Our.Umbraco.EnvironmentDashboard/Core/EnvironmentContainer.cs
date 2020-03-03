using System;
using System.Collections.Generic;
using System.Linq;

namespace Our.Umbraco.EnvironmentDashboard.Core
{
	public interface IEnvironmentContainer
	{
		IEnvironmentContainer AddEnvironment(string environmentName, string primaryDomain, params string[] domains);
	}

	internal class EnvironmentContainer : IEnvironmentContainer
	{
		private readonly Dictionary<string, IEnumerable<string>> _environments = new Dictionary<string, IEnumerable<string>>(StringComparer.OrdinalIgnoreCase);

		internal Dictionary<string, IEnumerable<string>> GetEnvironments()
		{
			return _environments;
		}

		public IEnvironmentContainer AddEnvironment(string environmentName, string primaryDomain, params string[] domains)
		{
			if (string.IsNullOrWhiteSpace(environmentName))
				throw new ArgumentException("Invalid environment name", nameof(environmentName));

			if (_environments.ContainsKey(environmentName))
				throw new ArgumentException($"The environment '{environmentName}' has already been added");

			if (string.IsNullOrWhiteSpace(primaryDomain))
				throw new ArgumentException("Invalid domain name", nameof(primaryDomain));

			if (domains != null && domains.Any(string.IsNullOrWhiteSpace))
				throw new ArgumentException("domains contain an invalid domain name", nameof(domains));

			// todo: most of the time it will not be null, and only have a single domain!!!???
			var combined = new List<string> { primaryDomain };
			combined.AddRange(domains);

			_environments.Add(environmentName, combined);

			return this;
		}
	}
}