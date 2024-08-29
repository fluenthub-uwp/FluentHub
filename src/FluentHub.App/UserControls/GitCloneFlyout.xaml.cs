using FluentHub.App.ViewModels.Repositories;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Serilog;

namespace FluentHub.App.UserControls
{
	public sealed partial class GitCloneFlyout : UserControl
	{
		#region propdp
		public static readonly DependencyProperty ViewModelProperty =
			DependencyProperty.Register(
				nameof(ViewModel),
				typeof(RepoContextViewModel),
				typeof(GitCloneFlyout),
				new PropertyMetadata(0));

		public RepoContextViewModel ViewModel
		{
			get => (RepoContextViewModel)GetValue(ViewModelProperty);
			set
			{
				SetValue(ViewModelProperty, value);
				DataContext = ViewModel;
			}
		}
		#endregion

		private string _repoGitUrl { get; set; }
		private string _repoUrl { get; set; }

		private string _cloneUrl;
		private string _sshUrl;
		private string _gitUrl;

		public GitCloneFlyout() => InitializeComponent();

		private void OnGitCloneFlyoutLoaded(object sender, RoutedEventArgs e)
		{
			_cloneUrl = $"https://github.com/{ViewModel.Repository.Owner.Login}/{ViewModel.Repository.Name}.git";
			_sshUrl = $"git@github.com:{ViewModel.Repository.Owner.Login}/{ViewModel.Repository.Name}.git";
			_gitUrl = $"gh repo clone {ViewModel.Repository.Owner.Login}/{ViewModel.Repository.Name}";

			CloneUriTextBox.Text = _cloneUrl;
			CloneDescriptionTextBlock.Text = "Use Git or checkout with SVN using the web URL.";

			_repoGitUrl = _cloneUrl;

			string input = _repoGitUrl;
			int index = input.LastIndexOf(".");
			if (index >= 0)
				input = input.Substring(0, index);

			_repoUrl = input;
		}

		private void GitCloneFlyoutNavView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
		{
			switch (args.InvokedItemContainer.Tag.ToString())
			{
				case "Https":
					CloneUriTextBox.Text = _cloneUrl;
					CloneDescriptionTextBlock.Text = "Use Git or checkout with SVN using the web URL.";
					break;
				case "Ssh":
					CloneUriTextBox.Text = _sshUrl;
					CloneDescriptionTextBlock.Text = "Use a password-protected SSH key.";
					break;
				case "GitHubCli":
					CloneUriTextBox.Text = _gitUrl;
					CloneDescriptionTextBlock.Text = "Work faster with GitHub's official CLI.";
					break;
			}
		}

		private void CopyButton_Click(object sender, RoutedEventArgs e)
		{
			var dp = new Windows.ApplicationModel.DataTransfer.DataPackage();
			dp.SetText(CloneUriTextBox.Text);
			Windows.ApplicationModel.DataTransfer.Clipboard.SetContent(dp);
		}

		private async void OpenVSButton_Click(object sender, RoutedEventArgs e)
		{
			string encodedUrl = Uri.EscapeDataString(_repoGitUrl);
			string openStudioUrl = "git-client://clone?repo=" + encodedUrl;

			var uri = new Uri(openStudioUrl);

			var success = await Windows.System.Launcher.LaunchUriAsync(uri);

			if (success)
			{
				Console.WriteLine("Add to LOG it successed");
			}
			else
			{
				Console.WriteLine("Add to LOG it failed");
			}
		}
		private async void OpenVSCodeButton_Click(object sender, RoutedEventArgs e)
		{
			string encodedUrl = Uri.EscapeDataString(_repoGitUrl);
			string openCodeUrl = "vscode://vscode.git/clone?url=" + encodedUrl; // There should be an API to detect Code Insiders and open that instead of the stable version

			var uri = new Uri(openCodeUrl);

			var success = await Windows.System.Launcher.LaunchUriAsync(uri);

			if (success)
			{
				Log.Write(Serilog.Events.LogEventLevel.Information, "Opened the repository in Visual Studio Code");
			}
			else
			{
				Log.Error(openCodeUrl, "Something went wrong. Code is not installed or there was another unspecified error.");
			}
		}

		private async void DownloadZipButton_Click(object sender, RoutedEventArgs e)
		{
			string downloadZipUrl = _repoUrl + $"/archive/refs/heads/{ViewModel.BranchName}.zip"; //Just made it with the main branch

			var uri = new Uri(downloadZipUrl);

			var success = await Windows.System.Launcher.LaunchUriAsync(uri);

			if (success)
			{
				Log.Write(Serilog.Events.LogEventLevel.Information, "Downloaded the repository into a .zip file");
			}
			else
			{
				Log.Error(downloadZipUrl, "Something went wrong. The URL was not found or it doesn't work");
			}
		}

		private async void GitHubDeskButton_Click(object sender, RoutedEventArgs e)
		{
			string encodedUrl = Uri.EscapeDataString(_repoGitUrl);
			string openGitHubDesktopUrl = "x-github-client://openRepo " + encodedUrl;

			var uri = new Uri(openGitHubDesktopUrl);

			var success = await Windows.System.Launcher.LaunchUriAsync(uri);

			if (success)
			{
				Log.Write(Serilog.Events.LogEventLevel.Information, "Opened GitHub Desktop with the repository");
			}
			else
			{
				Log.Error($"Cannot open GitHub Desktop with uri \"" + openGitHubDesktopUrl + "\"");
			}
		}

		private void CopyGitCommand_Click(object sender, RoutedEventArgs e)
		{
			var dp = new Windows.ApplicationModel.DataTransfer.DataPackage();
			dp.SetText("git clone" + " " + CloneUriTextBox.Text);
			Windows.ApplicationModel.DataTransfer.Clipboard.SetContent(dp);
		}
	}
}
