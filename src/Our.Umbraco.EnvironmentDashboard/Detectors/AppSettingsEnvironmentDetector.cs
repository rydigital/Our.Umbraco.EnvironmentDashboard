using System;
using System.Configuration;

namespace Our.Umbraco.EnvironmentDashboard.Detectors
{
	public class AppSettingsEnvironmentDetector : EnvironmentDetectorBase
	{
		public static readonly string DefaultAppSettingKey = "DashboardEnvironment";
		public static string DefaultEnvironment => "production";
		private readonly string _appSettingKey;

		public AppSettingsEnvironmentDetector() :this(DefaultAppSettingKey) {}
		public AppSettingsEnvironmentDetector(string appSettingKey)
		{
			if(appSettingKey == null)
				throw new ArgumentNullException(nameof(appSettingKey));

			if(string.IsNullOrWhiteSpace(appSettingKey))
				throw new ArgumentException($"the app setting key can not be empty or whitespace", nameof(appSettingKey));

			_appSettingKey = appSettingKey;
		}

		public override string Detect()
		{
			var configuredEnvironment = ConfigurationManager.AppSettings[_appSettingKey];
			return string.IsNullOrWhiteSpace(configuredEnvironment) ? base.Detect() : configuredEnvironment;
		}
	}
}