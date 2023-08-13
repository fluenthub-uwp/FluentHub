// Copyright (c) 2023 0x5BFA
// Licensed under the MIT License. See the LICENSE.

namespace FluentHub.Octokit.Models.v4
{
	/// <summary>
	/// Autogenerated input type of DeleteRepositoryRuleset
	/// </summary>
	public class DeleteRepositoryRulesetInput
	{
		/// <summary>
		/// The global relay id of the repository ruleset to be deleted.
		/// </summary>
		public ID RepositoryRulesetId { get; set; }

		/// <summary>
		/// A unique identifier for the client performing the mutation.
		/// </summary>
		public string ClientMutationId { get; set; }
	}
}
