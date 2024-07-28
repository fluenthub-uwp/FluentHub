// Copyright (c) 2022-2024 0x5BFA
// Licensed under the MIT License. See the LICENSE.

namespace FluentHub.Octokit.Models.v4
{
	/// <summary>
	/// Autogenerated input type of UpdateProjectV2ItemFieldValue
	/// </summary>
	public class UpdateProjectV2ItemFieldValueInput
	{
		/// <summary>
		/// A unique identifier for the client performing the mutation.
		/// </summary>
		public string ClientMutationId { get; set; }

		/// <summary>
		/// The ID of the Project.
		/// </summary>
		public ID ProjectId { get; set; }

		/// <summary>
		/// The ID of the item to be updated.
		/// </summary>
		public ID ItemId { get; set; }

		/// <summary>
		/// The ID of the field to be updated.
		/// </summary>
		public ID FieldId { get; set; }

		/// <summary>
		/// The value which will be set on the field.
		/// </summary>
		public ProjectV2FieldValue Value { get; set; }
	}
}
