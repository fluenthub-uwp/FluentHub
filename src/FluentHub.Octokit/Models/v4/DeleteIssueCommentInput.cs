// Copyright (c) 2023 0x5BFA
// Licensed under the MIT License. See the LICENSE.

namespace FluentHub.Octokit.Models.v4
{
	/// <summary>
	/// Autogenerated input type of DeleteIssueComment
	/// </summary>
	public class DeleteIssueCommentInput
	{
		/// <summary>
		/// The ID of the comment to delete.
		/// </summary>
		public ID Id { get; set; }

		/// <summary>
		/// A unique identifier for the client performing the mutation.
		/// </summary>
		public string ClientMutationId { get; set; }
	}
}
