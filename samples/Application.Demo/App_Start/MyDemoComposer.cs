using Our.Umbraco.EnvironmentDashboard.Components;
using Our.Umbraco.EnvironmentDashboard.Models;
using Umbraco.Core;
using Umbraco.Core.Composing;

namespace Application.Demo.Start_Up
{
	public class MyDemoComposer : IUserComposer
	{
		public void Compose(Composition composition)
		{
			composition.Components().Append<MyDemoComponent>();
		}
	}

	public class MyDemoComponent : IComponent
	{
		public void Initialize()
		{
			// Register as many environments as you wish
			EnvironmentInfo.Instance.Domains.Add(new DomainInfo("Local", "environmentdashboard.localhost"));
			EnvironmentInfo.Instance.Domains.Add(new DomainInfo("Development", "environmentdashboard-dev.localhost"));
			EnvironmentInfo.Instance.Domains.Add(new DomainInfo("QA", "environmentdashboard-qa.localhost"));
			EnvironmentInfo.Instance.Domains.Add(new DomainInfo("UAT", "environmentdashboard-qa.localhost"));
			EnvironmentInfo.Instance.Domains.Add(new DomainInfo("Production", "environmentdashboard-prod.localhost"));

			// Register my custom groups
			var group = new InfoGroup("My Custom Group Title");
			group.Pairs.Add(new InfoPair("my key", "my value"));
			EnvironmentInfo.Instance.Groups.Add(group);
		}

		public void Terminate()
		{
		}
	}
}