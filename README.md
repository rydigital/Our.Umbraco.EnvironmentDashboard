# Our.Umbraco.EnvironmentDashboard
## Environment dashboard for Umbraco ##
A simple dashboard for displaying environment specific information.

## Features
- Display the environment (eg. dev, qa, uat, prod)
- Display database server & database name the backoffice is using (out of the box)
- Ability to register any environment specific information to be displayed
- Browser tab shows environment

Suggested details to display:
- Azure Search index
- Azure Storage Account
- Relevant App Settings

## Getting Started ##
Nuget Package: ` Install-Package Our.Umbraco.EnvironmentDashboard `

## Usage ##
#### Composer ####
```
public class MyDemoComposer : IUserComposer
{
	public void Compose(Composition composition)
	{
		composition.Components().Append<MyDemoComponent>();
	}
}
```

#### Component ####
```
public class MyDemoComponent : IComponent
{
	public void Initialize()
	{
		// Register as many environments as you wish
		EnvironmentInfo.Instance.Domains.Add(new DomainInfo("Local", environmentdashboard.localhost"));
		EnvironmentInfo.Instance.Domains.Add(new DomainInfo("Development", environmentdashboard-dev.ry.com"));
		EnvironmentInfo.Instance.Domains.Add(new DomainInfo("QA", "environmentdashboard-qa.ry.com"));
		EnvironmentInfo.Instance.Domains.Add(new DomainInfo("UAT", "environmentdashboard-uat.ry.com"));
		EnvironmentInfo.Instance.Domains.Add(new DomainInfo("Production", "environmentdashboard.ry.com"));

		// Register my custom groups
		var group = new InfoGroup("My Custom Group");
		group.Pairs.Add(new InfoPair("My key", "My value"));
		EnvironmentInfo.Instance.Groups.Add(group);
	}

	public void Terminate() { }
}
```




