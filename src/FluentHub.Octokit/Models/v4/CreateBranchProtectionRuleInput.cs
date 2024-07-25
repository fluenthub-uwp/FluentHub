// Copyright (c) 2022-2024 0x5BFA
// Licensed under the MIT License. See the LICENSE.

namespace FluentHub.Octokit.Models.v4
{
	/// <summary>
	/// Autogenerated input type of CreateBranchProtectionRule
	/// </summary>
	public class CreateBranchProtectionRuleInput
	{
		/// <summary>
		/// A unique identifier for the client performing the mutation.
		/// </summary>
		public string ClientMutationId { get; set; }

		/// <summary>
		/// The global relay id of the repository in which a new branch protection rule should be created in.
		/// </summary>
		public ID RepositoryId { get; set; }

		/// <summary>
		/// The glob-like pattern used to determine matching branches.
		/// </summary>
		public string Pattern { get; set; }

		/// <summary>
		/// Are approving reviews required to update matching branches.
		/// </summary>
		public bool? RequiresApprovingReviews { get; set; }

		/// <summary>
		/// Number of approving reviews required to update matching branches.
		/// </summary>
		public int? RequiredApprovingReviewCount { get; set; }

		/// <summary>
		/// Are commits required to be signed.
		/// </summary>
		public bool? RequiresCommitSignatures { get; set; }

		/// <summary>
		/// Are merge commits prohibited from being pushed to this branch.
		/// </summary>
		public bool? RequiresLinearHistory { get; set; }

		/// <summary>
		/// Is branch creation a protected operation.
		/// </summary>
		public bool? BlocksCreations { get; set; }

		/// <summary>
		/// Are force pushes allowed on this branch.
		/// </summary>
		public bool? AllowsForcePushes { get; set; }

		/// <summary>
		/// Can this branch be deleted.
		/// </summary>
		public bool? AllowsDeletions { get; set; }

		/// <summary>
		/// Can admins override branch protection.
		/// </summary>
		public bool? IsAdminEnforced { get; set; }

		/// <summary>
		/// Are status checks required to update matching branches.
		/// </summary>
		public bool? RequiresStatusChecks { get; set; }

		/// <summary>
		/// Are branches required to be up to date before merging.
		/// </summary>
		public bool? RequiresStrictStatusChecks { get; set; }

		/// <summary>
		/// Are reviews from code owners required to update matching branches.
		/// </summary>
		public bool? RequiresCodeOwnerReviews { get; set; }

		/// <summary>
		/// Will new commits pushed to matching branches dismiss pull request review approvals.
		/// </summary>
		public bool? DismissesStaleReviews { get; set; }

		/// <summary>
		/// Is dismissal of pull request reviews restricted.
		/// </summary>
		public bool? RestrictsReviewDismissals { get; set; }

		/// <summary>
		/// A list of User, Team, or App IDs allowed to dismiss reviews on pull requests targeting matching branches.
		/// </summary>
		public List<ID> ReviewDismissalActorIds { get; set; }

		/// <summary>
		/// A list of User, Team, or App IDs allowed to bypass pull requests targeting matching branches.
		/// </summary>
		public List<ID> BypassPullRequestActorIds { get; set; }

		/// <summary>
		/// A list of User, Team, or App IDs allowed to bypass force push targeting matching branches.
		/// </summary>
		public List<ID> BypassForcePushActorIds { get; set; }

		/// <summary>
		/// Is pushing to matching branches restricted.
		/// </summary>
		public bool? RestrictsPushes { get; set; }

		/// <summary>
		/// A list of User, Team, or App IDs allowed to push to matching branches.
		/// </summary>
		public List<ID> PushActorIds { get; set; }

		/// <summary>
		/// List of required status check contexts that must pass for commits to be accepted to matching branches.
		/// </summary>
		public List<string> RequiredStatusCheckContexts { get; set; }

		/// <summary>
		/// The list of required status checks
		/// </summary>
		public List<RequiredStatusCheckInput> RequiredStatusChecks { get; set; }

		/// <summary>
		/// Are successful deployments required before merging.
		/// </summary>
		public bool? RequiresDeployments { get; set; }

		/// <summary>
		/// The list of required deployment environments
		/// </summary>
		public List<string> RequiredDeploymentEnvironments { get; set; }

		/// <summary>
		/// Are conversations required to be resolved before merging.
		/// </summary>
		public bool? RequiresConversationResolution { get; set; }

		/// <summary>
		/// Whether the most recent push must be approved by someone other than the person who pushed it
		/// </summary>
		public bool? RequireLastPushApproval { get; set; }

		/// <summary>
		/// Whether to set the branch as read-only. If this is true, users will not be able to push to the branch.
		/// </summary>
		public bool? LockBranch { get; set; }

		/// <summary>
		/// Whether users can pull changes from upstream when the branch is locked. Set to `true` to allow fork syncing. Set to `false` to prevent fork syncing.
		/// </summary>
		public bool? LockAllowsFetchAndMerge { get; set; }
	}
}
