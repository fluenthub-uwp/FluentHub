// Copyright (c) 2022-2024 0x5BFA
// Licensed under the MIT License. See the LICENSE.

namespace FluentHub.Octokit.Models.v4
{
	/// <summary>
	/// Autogenerated return type of UpdateEnterpriseAllowPrivateRepositoryForkingSetting
	/// </summary>
	public class UpdateEnterpriseAllowPrivateRepositoryForkingSettingPayload
	{
		/// <summary>
		/// A unique identifier for the client performing the mutation.
		/// </summary>
		public string ClientMutationId { get; set; }

		/// <summary>
		/// The enterprise with the updated allow private repository forking setting.
		/// </summary>
		public Enterprise Enterprise { get; set; }

		/// <summary>
		/// A message confirming the result of updating the allow private repository forking setting.
		/// </summary>
		public string Message { get; set; }
	}
}
