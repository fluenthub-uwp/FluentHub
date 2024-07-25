// Copyright (c) 2022-2024 0x5BFA
// Licensed under the MIT License. See the LICENSE.

namespace FluentHub.Octokit.Models.v4
{
	/// <summary>
	/// Autogenerated return type of CreateUserList
	/// </summary>
	public class CreateUserListPayload
	{
		/// <summary>
		/// A unique identifier for the client performing the mutation.
		/// </summary>
		public string ClientMutationId { get; set; }

		/// <summary>
		/// The list that was just created
		/// </summary>
		public UserList List { get; set; }

		/// <summary>
		/// The user who created the list
		/// </summary>
		public User Viewer { get; set; }
	}
}
