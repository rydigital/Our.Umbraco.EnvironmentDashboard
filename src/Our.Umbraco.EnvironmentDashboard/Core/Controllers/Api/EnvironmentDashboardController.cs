using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Our.Umbraco.EnvironmentDashboard.Core.Composing;
using Our.Umbraco.EnvironmentDashboard.Core.Detectors;
using Our.Umbraco.EnvironmentDashboard.Core.Models;
using Umbraco.Web.WebApi;

namespace Our.Umbraco.EnvironmentDashboard.Core.Controllers.Api
{
	public class EnvironmentDashboardController : UmbracoAuthorizedApiController
	{
		private readonly IEnvironmentDetector _environmentDetector;
		private readonly FactFamilyProviderCollection _factfamilyProviderCollection;
		
		public EnvironmentDashboardController(IEnvironmentDetector environmentDetector, FactFamilyProviderCollection factfamilyProviderCollection)
		{
			_factfamilyProviderCollection = factfamilyProviderCollection;
			_environmentDetector = environmentDetector;
		}

		[HttpGet]
		public HttpResponseMessage DashboardInfo()
		{
			var environment = _environmentDetector.Detect();

			var groups = _factfamilyProviderCollection.Select(gp => gp.Build(environment)).ToList();

			return Request.CreateResponse(
				HttpStatusCode.OK,
				new Dashboard
				{
					CurrentEnvironment = environment,
					Groups = groups
				}
			);
		}
	}
}