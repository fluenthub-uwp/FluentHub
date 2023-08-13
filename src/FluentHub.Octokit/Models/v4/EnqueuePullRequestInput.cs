// Copyright (c) 2023 0x5BFA
// Licensed under the MIT License. See the LICENSE.

namespace FluentHub.Octokit.Models.v4
{
	/// <summary>
	/// Autogenerated input type of EnqueuePullRequest
	/// </summary>
	public class EnqueuePullRequestInput
	{
		/// <summary>
		/// The ID of the pull request to enqueue.
		/// </summary>
		public ID PullRequestId { get; set; }

		/// <summary>
		/// Add the pull request to the front of the queue.
		/// </summary>
		public bool? Jump { get; set; }

		/// <summary>
		/// The expected head OID of the pull request.
		/// </summary>
		public string ExpectedHeadOid { get; set; }

		/// <summary>
		/// A unique identifier for the client performing the mutation.
		/// </summary>
		public string ClientMutationId { get; set; }
	}
}
