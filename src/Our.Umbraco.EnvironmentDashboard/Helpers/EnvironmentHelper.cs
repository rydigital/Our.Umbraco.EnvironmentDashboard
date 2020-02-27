using System;
using System.Linq;
using Our.Umbraco.EnvironmentDashboard.Attributes;
using Umbraco.Core;
using Environment = Our.Umbraco.EnvironmentDashboard.Enums.Environment;

namespace Our.Umbraco.EnvironmentDashboard.Helpers
{
	public static class EnvironmentHelper
	{
		public static Environment GetCurrentEnvironmentFromString(string environmentString)
		{
			var currentEnvironment = Environment.Unknown;
			var environments = Enum.GetValues(typeof(Environment)).Cast<Environment>();

			//loop environments
			foreach (var environment in environments)
			{
				//get match attribute from enum item
				var attribute = GetEnumAttribute<EnvironmentMatchAttribute>(environment);

				//see if any match the url
				if (attribute != null && environmentString.ContainsAny(attribute.MatchValues))
				{
					currentEnvironment = environment;
					break;
				}
			}

			return currentEnvironment;
		}

		private static T GetEnumAttribute<T>(this Enum enumValue) where T : Attribute
		{
			var type = enumValue.GetType();
			var memberInfo = type.GetMember(enumValue.ToString());
			var attributes = memberInfo[0].GetCustomAttributes(typeof(T), false);

			return (attributes.Length > 0) ? (T) attributes[0] : null;
		}
	}
}