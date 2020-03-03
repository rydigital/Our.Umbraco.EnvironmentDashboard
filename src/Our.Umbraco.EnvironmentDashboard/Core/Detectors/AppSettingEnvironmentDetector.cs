using System;
using System.Configuration;

namespace Our.Umbraco.EnvironmentDashboard.Core.Detectors
{
	public class AppSettingEnvironmentDetector : EnvironmentDetectorBase
	{
		public static readonly string DefaultAppSettingKey = "DashboardEnvironment";
		public static string DefaultEnvironment => "production";
		private readonly string _appSettingKey;

		public AppSettingEnvironmentDetector() : this(DefaultAppSettingKey) { }

		public AppSettingEnvironmentDetector(string appSettingKey)
		{
			if (string.IsNullOrWhiteSpace(appSettingKey))
				throw new ArgumentException($"AppSetting key can not be null or whitespace", nameof(appSettingKey));

			_appSettingKey = appSettingKey;
		}

		public override string Detect()
		{
			var configuredEnvironment = ConfigurationManager.AppSettings[_appSettingKey];

			return string.IsNullOrWhiteSpace(configuredEnvironment) ? base.Detect() : configuredEnvironment;
		}
	}
}