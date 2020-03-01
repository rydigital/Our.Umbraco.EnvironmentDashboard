using System;

namespace Our.Umbraco.EnvironmentDashboard
{
	public class DashboardEnvironment : IEquatable<DashboardEnvironment>
	{
		public static readonly DashboardEnvironment Unknown = new DashboardEnvironment("Unknown");

		public string Name { get; }

		public DashboardEnvironment(string name)
		{
			if(name == null)
				throw new ArgumentNullException(nameof(name));

			if(string.IsNullOrWhiteSpace(name))
				throw new ArgumentException("The environment name can not be empty", nameof(name));

			this.Name = name;
		}

		public bool Equals(DashboardEnvironment other)
		{
			if (ReferenceEquals(null, other))
				return false;

			if (ReferenceEquals(this, other))
				return true;
			
			return string.Equals(this.Name, other.Name, StringComparison.InvariantCultureIgnoreCase);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj))
				return false;

			if (ReferenceEquals(this, obj))
				return true;

			if (obj.GetType() != this.GetType())
				return false;

			return this.Equals((DashboardEnvironment) obj);
		}

		public override int GetHashCode() => (this.Name != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(this.Name) : 0);

		public static bool operator ==(DashboardEnvironment left, DashboardEnvironment right) => Equals(left, right);

		public static bool operator !=(DashboardEnvironment left, DashboardEnvironment right) => !Equals(left, right);

		public override string ToString() => this.Name;
	}
}