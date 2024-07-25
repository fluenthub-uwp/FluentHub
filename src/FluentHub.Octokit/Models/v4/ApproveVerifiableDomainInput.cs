// Copyright (c) 2022-2024 0x5BFA
// Licensed under the MIT License. See the LICENSE.

namespace FluentHub.Octokit.Models.v4
{
	/// <summary>
	/// Autogenerated input type of ApproveVerifiableDomain
	/// </summary>
	public class ApproveVerifiableDomainInput
	{
		/// <summary>
		/// A unique identifier for the client performing the mutation.
		/// </summary>
		public string ClientMutationId { get; set; }

		/// <summary>
		/// The ID of the verifiable domain to approve.
		/// </summary>
		public ID Id { get; set; }
	}
}
