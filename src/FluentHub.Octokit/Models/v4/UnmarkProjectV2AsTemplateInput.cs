// Copyright (c) 2023 0x5BFA
// Licensed under the MIT License. See the LICENSE.

namespace FluentHub.Octokit.Models.v4
{
	/// <summary>
	/// Autogenerated input type of UnmarkProjectV2AsTemplate
	/// </summary>
	public class UnmarkProjectV2AsTemplateInput
	{
		/// <summary>
		/// The ID of the Project to unmark as a template.
		/// </summary>
		public ID ProjectId { get; set; }

		/// <summary>
		/// A unique identifier for the client performing the mutation.
		/// </summary>
		public string ClientMutationId { get; set; }
	}
}
