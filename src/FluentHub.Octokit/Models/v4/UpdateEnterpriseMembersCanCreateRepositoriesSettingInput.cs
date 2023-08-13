// Copyright (c) 2023 0x5BFA
// Licensed under the MIT License. See the LICENSE.

namespace FluentHub.Octokit.Models.v4
{
	/// <summary>
	/// Autogenerated input type of UpdateEnterpriseMembersCanCreateRepositoriesSetting
	/// </summary>
	public class UpdateEnterpriseMembersCanCreateRepositoriesSettingInput
	{
		/// <summary>
		/// The ID of the enterprise on which to set the members can create repositories setting.
		/// </summary>
		public ID EnterpriseId { get; set; }

		/// <summary>
		/// Value for the members can create repositories setting on the enterprise. This or the granular public/private/internal allowed fields (but not both) must be provided.
		/// </summary>
		public EnterpriseMembersCanCreateRepositoriesSettingValue? SettingValue { get; set; }

		/// <summary>
		/// When false, allow member organizations to set their own repository creation member privileges.
		/// </summary>
		public bool? MembersCanCreateRepositoriesPolicyEnabled { get; set; }

		/// <summary>
		/// Allow members to create public repositories. Defaults to current value.
		/// </summary>
		public bool? MembersCanCreatePublicRepositories { get; set; }

		/// <summary>
		/// Allow members to create private repositories. Defaults to current value.
		/// </summary>
		public bool? MembersCanCreatePrivateRepositories { get; set; }

		/// <summary>
		/// Allow members to create internal repositories. Defaults to current value.
		/// </summary>
		public bool? MembersCanCreateInternalRepositories { get; set; }

		/// <summary>
		/// A unique identifier for the client performing the mutation.
		/// </summary>
		public string ClientMutationId { get; set; }
	}
}
