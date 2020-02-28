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
			EnvironmentInfo.Instance.Domains.Add(new DomainInfo("Development", "environmentdashboard-dev.ry.com"));
			EnvironmentInfo.Instance.Domains.Add(new DomainInfo("QA", "environmentdashboard-qa.ry.com"));
			EnvironmentInfo.Instance.Domains.Add(new DomainInfo("UAT", "environmentdashboard-uat.ry.com"));
			EnvironmentInfo.Instance.Domains.Add(new DomainInfo("Production", "environmentdashboard.ry.com"));

			// Register my custom groups
			var group = new InfoGroup("My Custom Group");
			group.Pairs.Add(new InfoPair("My key", "My value"));

			EnvironmentInfo.Instance.Groups.Add(group);
		}

		public void Terminate()
		{
		}
	}
}