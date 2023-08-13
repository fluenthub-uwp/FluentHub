// Copyright (c) 2023 0x5BFA
// Licensed under the MIT License. See the LICENSE.

namespace FluentHub.Octokit.Models.v4
{
	/// <summary>
	/// Autogenerated input type of UpdateEnterpriseMembersCanDeleteIssuesSetting
	/// </summary>
	public class UpdateEnterpriseMembersCanDeleteIssuesSettingInput
	{
		/// <summary>
		/// The ID of the enterprise on which to set the members can delete issues setting.
		/// </summary>
		public ID EnterpriseId { get; set; }

		/// <summary>
		/// The value for the members can delete issues setting on the enterprise.
		/// </summary>
		public EnterpriseEnabledDisabledSettingValue SettingValue { get; set; }

		/// <summary>
		/// A unique identifier for the client performing the mutation.
		/// </summary>
		public string ClientMutationId { get; set; }
	}
}
