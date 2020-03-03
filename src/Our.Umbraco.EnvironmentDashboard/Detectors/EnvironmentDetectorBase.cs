namespace Our.Umbraco.EnvironmentDashboard.Detectors
{
	public abstract class EnvironmentDetectorBase : IEnvironmentDetector
	{
		public static string UnknownEnvironment = "Unknown";

		public virtual string Detect() => UnknownEnvironment;
	}
}