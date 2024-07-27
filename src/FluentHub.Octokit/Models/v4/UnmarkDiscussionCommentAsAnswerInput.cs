// Copyright (c) 2022-2024 0x5BFA
// Licensed under the MIT License. See the LICENSE.

namespace FluentHub.Octokit.Models.v4
{
	/// <summary>
	/// Autogenerated input type of UnmarkDiscussionCommentAsAnswer
	/// </summary>
	public class UnmarkDiscussionCommentAsAnswerInput
	{
		/// <summary>
		/// A unique identifier for the client performing the mutation.
		/// </summary>
		public string ClientMutationId { get; set; }

		/// <summary>
		/// The Node ID of the discussion comment to unmark as an answer.
		/// </summary>
		public ID Id { get; set; }
	}
}
