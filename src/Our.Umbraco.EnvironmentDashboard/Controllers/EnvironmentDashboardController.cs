using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Our.Umbraco.EnvironmentDashboard.Composing;
using Our.Umbraco.EnvironmentDashboard.Models;
using Umbraco.Web.WebApi;

namespace Our.Umbraco.EnvironmentDashboard.Controllers
{
	public class EnvironmentDashboardController : UmbracoAuthorizedApiController
	{
		private readonly IEnvironmentDetector _environmentDetector;
		private readonly GroupsBuilderCollection _groupsBuilderCollection;
		
		public EnvironmentDashboardController(IEnvironmentDetector environmentDetector, GroupsBuilderCollection groupsBuilderCollection)
		{
			_groupsBuilderCollection = groupsBuilderCollection;
			_environmentDetector = environmentDetector;
		}

		[HttpGet]
		public HttpResponseMessage DashboardInfo()
		{
			var environment = _environmentDetector.Detect();

			var groups = _groupsBuilderCollection.SelectMany(gp => gp.Build(environment)).ToList();

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