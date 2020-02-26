using Application.Features.EnvironmentDashboard.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Application.Features.EnvironmentDashboard.Models
{
	public class EnvironmentInfo
	{
		[JsonProperty("currentEnvironment")]
		[JsonConverter(typeof(StringEnumConverter))]
		public Environment CurrentEnvironment { get; set; } = Environment.Unknown;

		[JsonProperty("databaseServer")]
		public string DatabaseServer { get; set; } = string.Empty;

		[JsonProperty("databaseName")]
		public string DatabaseName { get; set; } = string.Empty;

		[JsonProperty("cloudStorageUrl")]
		public string CloudStorageUrl { get; set; } = string.Empty;

		[JsonProperty("cloudStorageAccountName")]
		public string CloudStorageAccountName { get; set; } = string.Empty;
	}
}