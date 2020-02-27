using System.Net;
using System.Net.Http;
using System.Web.Http;
using Our.Umbraco.EnvironmentDashboard.Builders;
using Umbraco.Web.WebApi;

namespace Our.Umbraco.EnvironmentDashboard.Controllers
{
	public class EnvironmentDashboardController : UmbracoAuthorizedApiController
	{
		[HttpGet]
		public HttpResponseMessage DashboardInfo()
		{
			return this.Request.CreateResponse(
				HttpStatusCode.OK,
				EnvironmentInfoBuilder.Create()
			);
		}
	}
}