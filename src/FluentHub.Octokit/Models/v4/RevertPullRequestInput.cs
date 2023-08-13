// Copyright (c) 2023 0x5BFA
// Licensed under the MIT License. See the LICENSE.

namespace FluentHub.Octokit.Models.v4
{
	/// <summary>
	/// Autogenerated input type of RevertPullRequest
	/// </summary>
	public class RevertPullRequestInput
	{
		/// <summary>
		/// The ID of the pull request to revert.
		/// </summary>
		public ID PullRequestId { get; set; }

		/// <summary>
		/// The title of the revert pull request.
		/// </summary>
		public string Title { get; set; }

		/// <summary>
		/// The description of the revert pull request.
		/// </summary>
		public string Body { get; set; }

		/// <summary>
		/// Indicates whether the revert pull request should be a draft.
		/// </summary>
		public bool? Draft { get; set; }

		/// <summary>
		/// A unique identifier for the client performing the mutation.
		/// </summary>
		public string ClientMutationId { get; set; }
	}
}
