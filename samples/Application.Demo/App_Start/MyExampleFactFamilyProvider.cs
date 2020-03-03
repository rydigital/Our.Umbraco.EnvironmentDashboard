using Our.Umbraco.EnvironmentDashboard.Core.Detectors;
using Our.Umbraco.EnvironmentDashboard.Core.Models;
using Our.Umbraco.EnvironmentDashboard.Core.Providers;

namespace Application.Demo.App_Start
{
	public class MyExampleFactFamilyProvider : IFactFamilyProvider
	{
		public MyExampleFactFamilyProvider() 
		{ }

		public FactFamily Build(string environment)
		{
			if (environment == EnvironmentDetectorBase.UnknownEnvironment)
			{
				return new FactFamily("Environment is unknown, so we're not showing anything!");
			}

			var factFamily = new FactFamily("Umbraco Says...");

			if (environment == "Local" || environment == "Dev" || environment == "QA")
			{
				factFamily.Pairs.Add(new Fact("When I say 'Sea', you say Bass!", "..."));
				factFamily.Pairs.Add(new Fact("Sea", "Bass!"));
				factFamily.Pairs.Add(new Fact("Sea", "Bass!"));
			}
			
			if (environment == "UAT" || environment == "Prod")
			{
				factFamily.Pairs.Add(new Fact("Hi five.", "You ROCK!"));
			}

			return factFamily;
		}
	}
}