// Copyright (c) FluentHub
// Licensed under the MIT License. See the LICENSE.

using FluentHub.App.Data.Parameters;
using FluentHub.App.Services;
using FluentHub.App.ViewModels.Users;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media.Imaging;
using Microsoft.UI.Xaml.Navigation;

namespace FluentHub.App.Views.Users
{
	public sealed partial class DiscussionsPage : LocatablePage
	{
		public DiscussionsViewModel ViewModel { get; }

		public DiscussionsPage()
			: base(NavigationPageKind.User, NavigationPageKey.Discussions)
		{
			InitializeComponent();

			ViewModel = Ioc.Default.GetRequiredService<DiscussionsViewModel>();
		}

		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
			var command = ViewModel.LoadUserDiscussionsPageCommand;
			if (command.CanExecute(null))
				command.Execute(null);
		}

		private void OnScrollViewerViewChanged(object sender, ScrollViewerViewChangedEventArgs e)
		{
			var scrollViewer = (ScrollViewer)sender;
			if (scrollViewer.VerticalOffset == scrollViewer.ScrollableHeight)
			{
				var command = ViewModel.LoadFurtherUserDiscussionsPageCommand;
				if (command.CanExecute(null))
					command.Execute(null);
			}
		}
	}
}
