using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web;
using Our.Umbraco.EnvironmentDashboard.Helpers;
using Our.Umbraco.EnvironmentDashboard.Models;
using Microsoft.WindowsAzure.Storage;

namespace Our.Umbraco.EnvironmentDashboard.Builders
{
	public static class EnvironmentInfoBuilder
	{
		public static EnvironmentInfo Create()
		{
			return new EnvironmentInfo
			{
				CurrentEnvironment = EnvironmentHelper.GetCurrentEnvironmentFromString(HttpContext.Current.Request.Url.AbsoluteUri),
				DatabaseName = GetDatabaseName(),
				DatabaseServer = GetDatabaseServer(),
				CloudStorageUrl = GetAzureStorageUrl(),
				CloudStorageAccountName = GetAzureStorageAccountName()
			};
		}

		private static string GetAzureStorageUrl()
		{
			var cloudConnectionString = ConfigurationManager.AppSettings["AzureBlobFileSystem.ConnectionString:media"];

			try
			{
				var cloudStorageInfo= CloudStorageAccount.Parse(cloudConnectionString);

				return cloudStorageInfo.BlobStorageUri.PrimaryUri.AbsoluteUri;
			}
			catch
			{
				return string.Empty;
			}
		}


		private static string GetAzureStorageAccountName()
		{
			var cloudConnectionString = ConfigurationManager.AppSettings["AzureBlobFileSystem.ConnectionString:media"];

			try
			{
				var cloudStorageInfo = CloudStorageAccount.Parse(cloudConnectionString);

				return cloudStorageInfo.Credentials.AccountName;
			}
			catch
			{
				return string.Empty;
			}
		}


		private static string GetDatabaseServer()
		{
			var connectionString = ConfigurationManager.ConnectionStrings["umbracoDbDSN"].ConnectionString;

			if (connectionString.Contains(".sdf"))
			{
				return connectionString;
			}

			return new SqlConnectionStringBuilder(connectionString).DataSource;
		}

		private static string GetDatabaseName()
		{
			var connectionString = ConfigurationManager.ConnectionStrings["umbracoDbDSN"].ConnectionString;
			if (connectionString.Contains(".sdf"))
			{
				return connectionString;
			}

			return new SqlConnectionStringBuilder(connectionString).InitialCatalog;
		}
	}
}