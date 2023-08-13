// Copyright (c) 2023 0x5BFA
// Licensed under the MIT License. See the LICENSE.

namespace FluentHub.Octokit.Models.v4
{
	/// <summary>
	/// Autogenerated return type of UpdateEnterpriseMembersCanCreateRepositoriesSetting
	/// </summary>
	public class UpdateEnterpriseMembersCanCreateRepositoriesSettingPayload
	{
		/// <summary>
		/// A unique identifier for the client performing the mutation.
		/// </summary>
		public string ClientMutationId { get; set; }

		/// <summary>
		/// The enterprise with the updated members can create repositories setting.
		/// </summary>
		public Enterprise Enterprise { get; set; }

		/// <summary>
		/// A message confirming the result of updating the members can create repositories setting.
		/// </summary>
		public string Message { get; set; }
	}
}
