// Copyright (c) 2023 0x5BFA
// Licensed under the MIT License. See the LICENSE.

namespace FluentHub.Octokit.Models.v4
{
	/// <summary>
	/// Autogenerated return type of DeletePullRequestReview
	/// </summary>
	public class DeletePullRequestReviewPayload
	{
		/// <summary>
		/// A unique identifier for the client performing the mutation.
		/// </summary>
		public string ClientMutationId { get; set; }

		/// <summary>
		/// The deleted pull request review.
		/// </summary>
		public PullRequestReview PullRequestReview { get; set; }
	}
}
