using System.Net;
using System.Net.Http;
using System.Web.Http;
using Application.Features.EnvironmentDashboard.Builders;
using Umbraco.Web.WebApi;

namespace Application.Features.EnvironmentDashboard.Controllers
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