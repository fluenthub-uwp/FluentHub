// Copyright (c) 2022-2024 0x5BFA
// Licensed under the MIT License. See the LICENSE.

namespace FluentHub.Octokit.Models.v4
{
	/// <summary>
	/// Autogenerated input type of UpdateNotificationRestrictionSetting
	/// </summary>
	public class UpdateNotificationRestrictionSettingInput
	{
		/// <summary>
		/// A unique identifier for the client performing the mutation.
		/// </summary>
		public string ClientMutationId { get; set; }

		/// <summary>
		/// The ID of the owner on which to set the restrict notifications setting.
		/// </summary>
		public ID OwnerId { get; set; }

		/// <summary>
		/// The value for the restrict notifications setting.
		/// </summary>
		public NotificationRestrictionSettingValue SettingValue { get; set; }
	}
}
