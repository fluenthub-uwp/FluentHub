// Copyright (c) 2022-2024 0x5BFA
// Licensed under the MIT License. See the LICENSE.

namespace FluentHub.Octokit.Models.v4
{
	/// <summary>
	/// Autogenerated return type of CreateSponsorsListing
	/// </summary>
	public class CreateSponsorsListingPayload
	{
		/// <summary>
		/// A unique identifier for the client performing the mutation.
		/// </summary>
		public string ClientMutationId { get; set; }

		/// <summary>
		/// The new GitHub Sponsors profile.
		/// </summary>
		public SponsorsListing SponsorsListing { get; set; }
	}
}
