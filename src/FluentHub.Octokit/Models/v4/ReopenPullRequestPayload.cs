// Copyright (c) 2023 0x5BFA
// Licensed under the MIT License. See the LICENSE.

namespace FluentHub.Octokit.Models.v4
{
	/// <summary>
	/// Autogenerated return type of ReopenPullRequest
	/// </summary>
	public class ReopenPullRequestPayload
	{
		/// <summary>
		/// A unique identifier for the client performing the mutation.
		/// </summary>
		public string ClientMutationId { get; set; }

		/// <summary>
		/// The pull request that was reopened.
		/// </summary>
		public PullRequest PullRequest { get; set; }
	}
}
