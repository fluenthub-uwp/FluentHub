// Copyright (c) 2022-2024 0x5BFA
// Licensed under the MIT License. See the LICENSE.

namespace FluentHub.Octokit.Models.v4
{
	/// <summary>
	/// Autogenerated return type of CreateDeployment
	/// </summary>
	public class CreateDeploymentPayload
	{
		/// <summary>
		/// True if the default branch has been auto-merged into the deployment ref.
		/// </summary>
		public bool? AutoMerged { get; set; }

		/// <summary>
		/// A unique identifier for the client performing the mutation.
		/// </summary>
		public string ClientMutationId { get; set; }

		/// <summary>
		/// The new deployment.
		/// </summary>
		public Deployment Deployment { get; set; }
	}
}
