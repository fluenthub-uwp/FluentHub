// Copyright (c) 2023 0x5BFA
// Licensed under the MIT License. See the LICENSE.

namespace FluentHub.Octokit.Models.v4
{
	/// <summary>
	/// Autogenerated input type of UpdatePullRequestBranch
	/// </summary>
	public class UpdatePullRequestBranchInput
	{
		/// <summary>
		/// The Node ID of the pull request.
		/// </summary>
		public ID PullRequestId { get; set; }

		/// <summary>
		/// The head ref oid for the upstream branch.
		/// </summary>
		public string ExpectedHeadOid { get; set; }

		/// <summary>
		/// The update branch method to use. If omitted, defaults to 'MERGE'
		/// </summary>
		public PullRequestBranchUpdateMethod? UpdateMethod { get; set; }

		/// <summary>
		/// A unique identifier for the client performing the mutation.
		/// </summary>
		public string ClientMutationId { get; set; }
	}
}
