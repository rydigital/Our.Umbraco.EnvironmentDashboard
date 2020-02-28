using System.Net;
using System.Net.Http;
using System.Web.Http;
using Our.Umbraco.EnvironmentDashboard.Models;
using Umbraco.Web.WebApi;

namespace Our.Umbraco.EnvironmentDashboard.Controllers
{
	public class EnvironmentDashboardController : UmbracoAuthorizedApiController
	{
		[HttpGet]
		public HttpResponseMessage DashboardInfo()
		{
			EnvironmentInfo.Instance.SetCurrentEnvironment(Request.RequestUri.Authority);

			return this.Request.CreateResponse(
				HttpStatusCode.OK,
				EnvironmentInfo.Instance
			);
		}
	}
}