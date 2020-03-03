using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Umbraco.Web;

namespace Our.Umbraco.EnvironmentDashboard.Detectors
{
	public class DomainEnvironmentDetector : EnvironmentDetectorBase
	{
		private readonly IHttpContextAccessor _httpContextAccessor;
		private readonly ImmutableDictionary<string, ImmutableHashSet<string>> _environments;

		public DomainEnvironmentDetector(IHttpContextAccessor httpContextAccessor,  Dictionary<string, string[]> environments)
		{
			if (httpContextAccessor == null)
				throw new ArgumentNullException(nameof(httpContextAccessor));

			if (environments == null)
				throw new ArgumentNullException(nameof(environments));

			_httpContextAccessor = httpContextAccessor;

			_environments = environments.ToImmutableDictionary(kv => kv.Key, kv => kv.Value.Where(uri => uri != null).Select(uri => uri.ToLowerInvariant()).ToImmutableHashSet(StringComparer.OrdinalIgnoreCase));
		}

		public override string Detect()
		{
			string urlAuthority = _httpContextAccessor.HttpContext?.Request.Url.Authority;

			return GetCurrentEnvironment(urlAuthority ?? string.Empty);
		}

		private string GetCurrentEnvironment(string urlAuthority)
		{
			var cleanedDomain = urlAuthority
			                   .ToLowerInvariant()
			                   .Replace("http://", string.Empty)
			                   .Replace("https://", string.Empty)
			                   .Trim();

			foreach (var environment in _environments)
			{
				if (environment.Value.Contains(cleanedDomain))
				{
					return environment.Key;
				}
			}

			return base.Detect();
		}
	}
}