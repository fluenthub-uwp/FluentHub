using FluentHub.App.Services;
using FluentHub.App.ViewModels.Repositories;
using FluentHub.App.ViewModels.Repositories.Commits;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Navigation;
using Microsoft.UI.Xaml.Media.Imaging;
using FluentHub.App.Data.Parameters;

namespace FluentHub.App.Views.Repositories.Commits
{
	public sealed partial class CommitsPage : LocatablePage
	{
		public CommitsViewModel ViewModel { get; }
		private readonly INavigationService _navigation;

		public CommitsPage()
			: base(NavigationPageKind.Repository, NavigationPageKey.Code)
		{
			InitializeComponent();

			ViewModel = Ioc.Default.GetRequiredService<CommitsViewModel>();
			_navigation = Ioc.Default.GetRequiredService<INavigationService>();
		}

		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
			var param = e.Parameter as FrameNavigationParameter;
			ViewModel.Login = param.PrimaryText;
			ViewModel.Name = param.SecondaryText;
			ViewModel.ContextViewModel = param.Parameters as RepoContextViewModel;

			var command = ViewModel.LoadRepositoryCommitsPageCommand;
			if (command.CanExecute(null))
				command.Execute(null);
		}
	}
}
