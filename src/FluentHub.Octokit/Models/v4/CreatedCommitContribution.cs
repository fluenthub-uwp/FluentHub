// Copyright (c) 2022-2024 0x5BFA
// Licensed under the MIT License. See the LICENSE.

namespace FluentHub.Octokit.Models.v4
{
	/// <summary>
	/// Represents the contribution a user made by committing to a repository.
	/// </summary>
	public class CreatedCommitContribution
	{
		/// <summary>
		/// How many commits were made on this day to this repository by the user.
		/// </summary>
		public int CommitCount { get; set; }

		/// <summary>
		/// Whether this contribution is associated with a record you do not have access to. For
		/// example, your own 'first issue' contribution may have been made on a repository you can no
		/// longer access.
		/// </summary>
		public bool IsRestricted { get; set; }

		/// <summary>
		/// When this contribution was made.
		/// </summary>
		public DateTimeOffset OccurredAt { get; set; }

		/// <summary>
		/// Humanized string of "When this contribution was made."
		/// <summary>
		public string OccurredAtHumanized { get; set; }

		/// <summary>
		/// The repository the user made a commit in.
		/// </summary>
		public Repository Repository { get; set; }

		/// <summary>
		/// The HTTP path for this contribution.
		/// </summary>
		public string ResourcePath { get; set; }

		/// <summary>
		/// The HTTP URL for this contribution.
		/// </summary>
		public string Url { get; set; }

		/// <summary>
		/// The user who made this contribution.
		/// </summary>
		public User User { get; set; }
	}
}
