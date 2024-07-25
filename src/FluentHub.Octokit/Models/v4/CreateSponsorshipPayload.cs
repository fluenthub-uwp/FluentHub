// Copyright (c) 2022-2024 0x5BFA
// Licensed under the MIT License. See the LICENSE.

namespace FluentHub.Octokit.Models.v4
{
	/// <summary>
	/// Autogenerated return type of CreateSponsorship
	/// </summary>
	public class CreateSponsorshipPayload
	{
		/// <summary>
		/// A unique identifier for the client performing the mutation.
		/// </summary>
		public string ClientMutationId { get; set; }

		/// <summary>
		/// The sponsorship that was started.
		/// </summary>
		public Sponsorship Sponsorship { get; set; }
	}
}
