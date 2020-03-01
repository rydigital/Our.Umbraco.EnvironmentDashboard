using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Our.Umbraco.EnvironmentDashboard.Components;
using Our.Umbraco.EnvironmentDashboard.Models;
using Umbraco.Web.WebApi;

namespace Our.Umbraco.EnvironmentDashboard.Controllers
{
	public class EnvironmentDashboardController : UmbracoAuthorizedApiController
	{
		private readonly IDashboardEnvironmentProvider _environmentProvider;
		private readonly EnvironmentDashboardGroupsCollection _groupsCollection;
		
		public EnvironmentDashboardController(IDashboardEnvironmentProvider environmentProvider, EnvironmentDashboardGroupsCollection groupsCollection)
		{
			_groupsCollection = groupsCollection;
			_environmentProvider = environmentProvider;
		}

		[HttpGet]
		public HttpResponseMessage DashboardInfo()
		{
			var environment = _environmentProvider.GetEnvironment();

			var groups = _groupsCollection.SelectMany(gp => gp.GetGroups(environment)).ToList();

			return Request.CreateResponse(
				HttpStatusCode.OK,
				new EnvironmentInfo
				{
					CurrentEnvironment = environment.Name,
					Groups = groups,
					Domains = new List<DomainInfo>(),
				}
			);
		}
	}
}