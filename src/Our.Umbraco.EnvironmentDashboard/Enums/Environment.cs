using Application.Features.EnvironmentDashboard.Attributes;

namespace Application.Features.EnvironmentDashboard.Enums
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