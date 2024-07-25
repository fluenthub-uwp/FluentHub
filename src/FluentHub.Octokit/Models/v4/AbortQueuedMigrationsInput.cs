// Copyright (c) 2022-2024 0x5BFA
// Licensed under the MIT License. See the LICENSE.

namespace FluentHub.Octokit.Models.v4
{
	/// <summary>
	/// Autogenerated input type of AbortQueuedMigrations
	/// </summary>
	public class AbortQueuedMigrationsInput
	{
		/// <summary>
		/// A unique identifier for the client performing the mutation.
		/// </summary>
		public string ClientMutationId { get; set; }

		/// <summary>
		/// The ID of the organization that is running the migrations.
		/// </summary>
		public ID OwnerId { get; set; }
	}
}
