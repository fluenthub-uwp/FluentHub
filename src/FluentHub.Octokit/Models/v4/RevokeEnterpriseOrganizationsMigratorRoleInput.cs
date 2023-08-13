// Copyright (c) 2023 0x5BFA
// Licensed under the MIT License. See the LICENSE.

namespace FluentHub.Octokit.Models.v4
{
	/// <summary>
	/// Autogenerated input type of RevokeEnterpriseOrganizationsMigratorRole
	/// </summary>
	public class RevokeEnterpriseOrganizationsMigratorRoleInput
	{
		/// <summary>
		/// The ID of the enterprise to which all organizations managed by it will be granted the migrator role.
		/// </summary>
		public ID EnterpriseId { get; set; }

		/// <summary>
		/// The login of the user to revoke the migrator role
		/// </summary>
		public string Login { get; set; }

		/// <summary>
		/// A unique identifier for the client performing the mutation.
		/// </summary>
		public string ClientMutationId { get; set; }
	}
}
