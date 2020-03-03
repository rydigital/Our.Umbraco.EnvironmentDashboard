namespace Our.Umbraco.EnvironmentDashboard.Core.Detectors
{
	public abstract class EnvironmentDetectorBase : IEnvironmentDetector
	{
		public static string UnknownEnvironment = "Unknown";

		public virtual string Detect() => UnknownEnvironment;
	}
}