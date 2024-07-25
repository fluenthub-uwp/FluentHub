// Copyright (c) 2022-2024 0x5BFA
// Licensed under the MIT License. See the LICENSE.

namespace FluentHub.Octokit.Models.v4
{
	/// <summary>
	/// Autogenerated return type of CreateProjectV2Field
	/// </summary>
	public class CreateProjectV2FieldPayload
	{
		/// <summary>
		/// A unique identifier for the client performing the mutation.
		/// </summary>
		public string ClientMutationId { get; set; }

		/// <summary>
		/// The new field.
		/// </summary>
		public ProjectV2FieldConfiguration ProjectV2Field { get; set; }
	}
}
