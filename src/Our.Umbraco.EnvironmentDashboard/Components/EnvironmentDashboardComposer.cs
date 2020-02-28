using Our.Umbraco.EnvironmentDashboard.Models;
using Umbraco.Core;
using Umbraco.Core.Composing;

namespace Our.Umbraco.EnvironmentDashboard.Components
{
	public class EnvironmentDashboardComposer : IUserComposer
	{
		public void Compose(Composition composition)
		{
			composition.Components().Insert<EnvironmentDashboardComponent>();
		}
	}

	public class EnvironmentDashboardComponent : IComponent
	{
		public void Initialize()
		{
			// TODO: add connection string
			var databaseGroup = new InfoGroup("Database Settings");
			databaseGroup.Pairs.Add(new InfoPair("Server", "server value"));
			databaseGroup.Pairs.Add(new InfoPair("Database Name", "database name value"));
			EnvironmentInfo.Instance.Groups.Add(databaseGroup);


			// TODO: add connection azure storage
			var blobGroup = new InfoGroup("Blob Settings");
			blobGroup.Pairs.Add(new InfoPair("blobkey", "blobvalue"));
			EnvironmentInfo.Instance.Groups.Add(blobGroup);
		}

		public void Terminate()
		{
		}
	}
}