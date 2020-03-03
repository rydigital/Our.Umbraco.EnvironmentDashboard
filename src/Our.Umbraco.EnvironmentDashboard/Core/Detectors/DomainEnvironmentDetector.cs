using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Umbraco.Web;

namespace Our.Umbraco.EnvironmentDashboard.Core.Detectors
{
	public class DomainEnvironmentDetector : EnvironmentDetectorBase
	{
		private readonly IHttpContextAccessor _httpContextAccessor;
		private readonly Dictionary<string, IEnumerable<string>> _environments;

		public DomainEnvironmentDetector(IHttpContextAccessor httpContextAccessor,  Dictionary<string, IEnumerable<string>> environments)
		{
			_httpContextAccessor = httpContextAccessor;
			_environments = environments;
		}

		public override string Detect()
		{
			string urlAuthority = _httpContextAccessor.HttpContext.Request.Url.Authority;

			return GetCurrentEnvironment(urlAuthority);
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