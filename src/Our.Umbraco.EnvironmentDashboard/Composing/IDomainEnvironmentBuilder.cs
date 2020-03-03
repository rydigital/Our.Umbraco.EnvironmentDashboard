namespace Our.Umbraco.EnvironmentDashboard.Composing
{
	public interface IDomainEnvironmentBuilder
	{
		IDomainEnvironmentBuilder AddEnvironment(string environmentName, string primaryDomain,
			params string[] domains);
	}
}