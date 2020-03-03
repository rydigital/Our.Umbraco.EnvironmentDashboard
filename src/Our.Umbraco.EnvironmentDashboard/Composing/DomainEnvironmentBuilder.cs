using System;
using System.Collections.Generic;
using System.Linq;

namespace Our.Umbraco.EnvironmentDashboard.Composing
{
	internal class DomainEnvironmentBuilder : IDomainEnvironmentBuilder
	{
		private readonly Dictionary<string, string[]> _domainEnvironments =
			new Dictionary<string, string[]>(StringComparer.OrdinalIgnoreCase);

		public IDomainEnvironmentBuilder AddEnvironment(string environmentName, string primaryDomain,
			params string[] domains)
		{
			if (string.IsNullOrWhiteSpace(environmentName))
				throw new ArgumentException("Invalid environment name", nameof(environmentName));

			if (this._domainEnvironments.ContainsKey(environmentName))
				throw new ArgumentException($"the environment '{environmentName}' has already been added");

			if (string.IsNullOrWhiteSpace(primaryDomain))
				throw new ArgumentException("Invalid domain name", nameof(primaryDomain));

			if (domains != null && domains.Any(string.IsNullOrWhiteSpace))
				throw new ArgumentException("domains contain an invalid domain name", nameof(domains));

			this._domainEnvironments.Add(environmentName, new[] {primaryDomain}.Concat(domains ?? new string[0])
				.ToArray());

			return this;
		}

		internal Dictionary<string, string[]> GetDomainEnvironments()
		{
			return this._domainEnvironments;
		}
	}
}