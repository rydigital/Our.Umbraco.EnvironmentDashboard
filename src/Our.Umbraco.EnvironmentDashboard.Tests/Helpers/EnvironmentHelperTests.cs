using Application.Features.EnvironmentDashboard.Enums;
using Application.Features.EnvironmentDashboard.Helpers;
using NUnit.Framework;

namespace Application.Features.EnvironmentDashboard.Tests.Helpers
{
	[TestFixture]
	public class EnvironmentHelperTests
	{
		[TestCase("xxx", ExpectedResult = Environment.Unknown)]
		[TestCase("local", ExpectedResult = Environment.Local)]
		[TestCase(".local", ExpectedResult = Environment.Local)]
		[TestCase("dev", ExpectedResult = Environment.Dev)]
		[TestCase("-dev", ExpectedResult = Environment.Dev)]
		[TestCase("qa", ExpectedResult = Environment.QA)]
		[TestCase("prod", ExpectedResult = Environment.Production)]
		[TestCase("production-website.com", ExpectedResult = Environment.Production)]
		public Environment Should_Match_Enum_When_Getting_The_Environment_From_String(string environmentString)
		{
			return EnvironmentHelper.GetCurrentEnvironmentFromString(environmentString);
		}

		[TestCase("https://myproject.local", ExpectedResult = Environment.Local)]
		[TestCase("https://app-myproject-dev.azurewebsites.net/", ExpectedResult = Environment.Dev)]
		[TestCase("https://app-myproject-qa.azurewebsites.net/", ExpectedResult = Environment.QA)]
		[TestCase("https://app-myproject-cm-uat.azurewebsites.net/", ExpectedResult = Environment.UAT)]
		[TestCase("https://app-myproject-cm-prod.azurewebsites.net/", ExpectedResult = Environment.Production)]
		[TestCase("https://myproject.com/", ExpectedResult = Environment.Production)]
		public Environment Should_Match_Enum_When_Getting_The_Environment_From_URL(string environmentString)
		{
			return EnvironmentHelper.GetCurrentEnvironmentFromString(environmentString);
		}
	}
}
