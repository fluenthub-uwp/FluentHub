// Copyright (c) 2023 0x5BFA
// Licensed under the MIT License. See the LICENSE.

namespace FluentHub.Octokit.Models.v4
{
	/// <summary>
	/// Autogenerated input type of DeleteVerifiableDomain
	/// </summary>
	public class DeleteVerifiableDomainInput
	{
		/// <summary>
		/// The ID of the verifiable domain to delete.
		/// </summary>
		public ID Id { get; set; }

		/// <summary>
		/// A unique identifier for the client performing the mutation.
		/// </summary>
		public string ClientMutationId { get; set; }
	}
}
