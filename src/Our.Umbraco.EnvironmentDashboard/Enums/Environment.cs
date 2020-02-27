using Our.Umbraco.EnvironmentDashboard.Attributes;

namespace Our.Umbraco.EnvironmentDashboard.Enums
{
	public enum Environment
	{
		Unknown,

		[EnvironmentMatch("local,.local")]
		Local,

		[EnvironmentMatch("dev,-dev")]
		Dev,

		[EnvironmentMatch("uat,-uat")]
		UAT,

		[EnvironmentMatch("qa,-qa")]
		QA,

		[EnvironmentMatch("prod,-prod,.com,.co.uk")]
		Production
	}
}