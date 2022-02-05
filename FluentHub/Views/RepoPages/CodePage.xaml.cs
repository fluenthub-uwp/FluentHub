﻿using Humanizer;
using FluentHub.Services.OctokitEx;
using Octokit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;


namespace FluentHub.Views.RepoPages
{
    public sealed partial class CodePage : Windows.UI.Xaml.Controls.Page
    {
        private long RepoId { get; set; }
        private Repository Repository { get; set; }
        private Readme Readme { get; set; }

        public CodePage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            RepoId = Convert.ToInt64(e.Parameter as string);
        }

        private void OverviewColumnCloseButton_Click(object sender, RoutedEventArgs e)
        {
            OverviewColumn.Width = new GridLength(0);
            OverviewColumnOpenButton.Visibility = Visibility.Visible;
        }

        private void OverviewColumnOpenButton_Click(object sender, RoutedEventArgs e)
        {
            OverviewColumn.Width = new GridLength(256);
            OverviewColumnOpenButton.Visibility = Visibility.Collapsed;
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Repository = await App.Client.Repository.Get(RepoId);

            string repoDescription = Repository.Description;

            if(string.IsNullOrEmpty(repoDescription) == false)
            {
                RepoDescription.Text = repoDescription;
            }
            else
            {
                RepoDescription.Text = "No description found for this repositiry.";
                RepoDescription.FontStyle = Windows.UI.Text.FontStyle.Italic;
            }

            if (Readme != null)
            {
                OverviewReadmeBlock.Visibility = Visibility.Visible;
            }

            if (Repository.License != null)
            {
                OverviewLicenseBlock.Visibility = Visibility.Visible;
                OverviewLicense.Content = Repository.License.Name;
            }

            OverviewStargazersCount.Content = Repository.StargazersCount.ToString() + " Stars";

            OverviewWatchingCount.Content = Repository.WatchersCount.ToString() + " Watching";

            OverviewForksCount.Content = Repository.ForksCount.ToString() + " Forks";

            var branches = await App.Client.Repository.Branch.GetAll(RepoId);

            BranchesCountTextBlock.Text = branches.Count().ToString();

            var tags = await App.Client.Repository.GetAllTags(RepoId);

            TagsCountTextBlock.Text = tags.Count().ToString();

            var commits = await App.Client.Repository.Commit.GetAll(RepoId);

            RepoLatestCommitAuthorAvatar.Source = new BitmapImage(new Uri(commits[0].Author.AvatarUrl));

            RepoLatestCommitAuthorName.Text = commits[0].Author.Login;

            RepoLatestCommitMessage.Text = commits[0].Commit.Message.Split("\n")[0];

            RepoLatestCommitSha.Text = commits[0].Sha.Substring(0, 7);

            RepoLatestCommitUpdatedAtHumanized.Text = commits[0].Commit.Author.Date.Humanize();

            RepoCommitsCount.Text = commits.Count().ToString();

            await ViewModel.EnumRepositoryContents(RepoId);
        }

        private void RepositoryReadmeWebView_NavigationStarting(WebView sender, WebViewNavigationStartingEventArgs args)
        {
            if (args.Uri != null)
            {
                args.Cancel = true;
            }
        }

        private async void RepositoryReadmeWebView_Loaded(object sender, RoutedEventArgs e)
        {
            Readme = await App.Client.Repository.Content.GetReadme(RepoId);
            Markdown markdown = new Markdown();

            if (Readme == null)
            {
                return;
            }
            else
            {
                RepositoryReadmeBlock.Visibility = Visibility.Visible;
            }

            string result = await markdown.FormatRenderedMarkdownToHtml(await Readme.GetHtmlContent());

            RepositoryReadmeWebView.NavigateToString(result);
        }

        private async void RepositoryReadmeWebView_NavigationCompleted(WebView sender, WebViewNavigationCompletedEventArgs args)
        {
            string returnStr = await RepositoryReadmeWebView.InvokeScriptAsync("eval", new string[] { SetBodyOverFlowHiddenString });
            int heightScroll = 0;
            var heightScrollStr = await RepositoryReadmeWebView.InvokeScriptAsync("eval", new[] { "document.body.scrollHeight.toString()" });

            if (int.TryParse(heightScrollStr, out heightScroll))
            {
                RepositoryReadmeWebView.Height = heightScroll;
            }
        }


        string SetBodyOverFlowHiddenString
            = @" function SetBodyOverFlowHidden()
                {
                    document.body.style.overflow = 'hidden';
                    return 'Set Style to hidden';
                }
                SetBodyOverFlowHidden();
            ";

        private void Page_Loading(FrameworkElement sender, object args)
        {
            GitCloneFlyout.RepositoryId = RepoId;

        }
    }
}
