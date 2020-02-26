using System.Configuration;
using System.Data.SqlClient;
using System.Web;
using Application.Features.EnvironmentDashboard.Helpers;
using Application.Features.EnvironmentDashboard.Models;
using Microsoft.WindowsAzure.Storage;

namespace Application.Features.EnvironmentDashboard.Builders
{
	public static class EnvironmentInfoBuilder
	{
		public static EnvironmentInfo Create()
		{
			var connectionString = GetDatabaseConnectionString();
			var cloudStorageInfo = GetCloudStorageAccount();

			return new EnvironmentInfo
			{
				CurrentEnvironment = EnvironmentHelper.GetCurrentEnvironmentFromString(HttpContext.Current.Request.Url.AbsoluteUri),
				DatabaseName = connectionString.InitialCatalog,
				DatabaseServer = connectionString.DataSource,
				CloudStorageUrl = cloudStorageInfo.BlobStorageUri.PrimaryUri.AbsoluteUri,
				CloudStorageAccountName = cloudStorageInfo.Credentials.AccountName
			};
		}

		private static CloudStorageAccount GetCloudStorageAccount()
		{
			var cloudConnectionString = ConfigurationManager.AppSettings["AzureBlobFileSystem.ConnectionString:media"];
			return CloudStorageAccount.Parse(cloudConnectionString);
		}

		private static SqlConnectionStringBuilder GetDatabaseConnectionString()
		{
			var umbracoConnectionString = ConfigurationManager.ConnectionStrings["umbracoDbDSN"].ConnectionString;
			return new SqlConnectionStringBuilder(umbracoConnectionString);
		}
	}
}