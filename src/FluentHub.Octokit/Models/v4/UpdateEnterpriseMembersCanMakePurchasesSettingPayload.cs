// Copyright (c) 2022-2024 0x5BFA
// Licensed under the MIT License. See the LICENSE.

namespace FluentHub.Octokit.Models.v4
{
	/// <summary>
	/// Autogenerated return type of UpdateEnterpriseMembersCanMakePurchasesSetting
	/// </summary>
	public class UpdateEnterpriseMembersCanMakePurchasesSettingPayload
	{
		/// <summary>
		/// A unique identifier for the client performing the mutation.
		/// </summary>
		public string ClientMutationId { get; set; }

		/// <summary>
		/// The enterprise with the updated members can make purchases setting.
		/// </summary>
		public Enterprise Enterprise { get; set; }

		/// <summary>
		/// A message confirming the result of updating the members can make purchases setting.
		/// </summary>
		public string Message { get; set; }
	}
}
