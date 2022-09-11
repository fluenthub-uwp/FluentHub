﻿using FluentHub.Octokit.Queries.Users;
using FluentHub.Uwp.Helpers;
using FluentHub.Uwp.Models;
using FluentHub.Uwp.Services;
using FluentHub.Uwp.ViewModels.Repositories;
using FluentHub.Uwp.ViewModels.UserControls;
using FluentHub.Uwp.ViewModels.UserControls.ButtonBlocks;
using FluentHub.Uwp.Utils;
using Microsoft.Extensions.DependencyInjection;
using Windows.UI.Xaml.Media.Imaging;
using muxc = Microsoft.UI.Xaml.Controls;

namespace FluentHub.Uwp.ViewModels.Users
{
    public class OverviewViewModel : ObservableObject
    {
        public OverviewViewModel(IMessenger messenger = null, ILogger logger = null)
        {
            _logger = logger;
            _messenger = messenger;

            _pinnedRepositories = new();
            PinnedRepositories = new(_pinnedRepositories);

            _pinnableRepositories = new();
            PinnableRepositories = new(_pinnableRepositories);

            LoadUserOverviewCommand = new AsyncRelayCommand(LoadUserOverviewAsync);
            ShowPinnedRepositoriesEditorDialogCommand = new AsyncRelayCommand(ShowPinnedRepositoriesEditorDialogAsync);
        }

        #region Fields and Properties
        private readonly ILogger _logger;
        private readonly IMessenger _messenger;

        private string _login;
        public string Login { get => _login; set => SetProperty(ref _login, value); }

        private User _user;
        public User User { get => _user; set => SetProperty(ref _user, value); }

        private UserProfileOverviewViewModel _userProfileOverviewViewModel;
        public UserProfileOverviewViewModel UserProfileOverviewViewModel { get => _userProfileOverviewViewModel; set => SetProperty(ref _userProfileOverviewViewModel, value); }

        private readonly ObservableCollection<RepoButtonBlockViewModel> _pinnedRepositories;
        public ReadOnlyObservableCollection<RepoButtonBlockViewModel> PinnedRepositories { get; }

        private readonly ObservableCollection<RepoButtonBlockViewModel> _pinnableRepositories;
        public ReadOnlyObservableCollection<RepoButtonBlockViewModel> PinnableRepositories { get; }

        private RepoContextViewModel _contextViewModel;
        public RepoContextViewModel ContextViewModel { get => _contextViewModel; set => SetProperty(ref _contextViewModel, value); }

        private Exception _taskException;
        public Exception TaskException { get => _taskException; set => SetProperty(ref _taskException, value); }

        public IAsyncRelayCommand LoadUserOverviewCommand { get; }
        public IAsyncRelayCommand ShowPinnedRepositoriesEditorDialogCommand { get; }
        #endregion

        private async Task LoadUserOverviewAsync()
        {
            _messenger?.Send(new TaskStateMessaging(TaskStatusType.IsStarted));
            bool faulted = false;

            string _currentTaskingMethodName = nameof(LoadUserOverviewAsync);

            try
            {
                _currentTaskingMethodName = nameof(LoadUserAsync);
                await LoadUserAsync(Login);

                _currentTaskingMethodName = nameof(LoadUserPinnableAndPinnedRepositoriesAsync);
                await LoadUserPinnableAndPinnedRepositoriesAsync(Login);
            }
            catch (Exception ex)
            {
                TaskException = ex;
                faulted = true;

                _logger?.Error(_currentTaskingMethodName, ex);
                throw;
            }
            finally
            {
                SetCurrentTabItem();
                _messenger?.Send(new TaskStateMessaging(faulted ? TaskStatusType.IsFaulted : TaskStatusType.IsCompletedSuccessfully));
            }
        }

        private async Task LoadUserPinnableAndPinnedRepositoriesAsync(string login)
        {
            _pinnableRepositories.Clear();
            _pinnedRepositories.Clear();

            PinnedItemQueries queries = new();
            var pinnedItemsRes = await queries.GetAllAsync(login);
            if (pinnedItemsRes == null) return;

            if (pinnedItemsRes.Count == 0)
            {
                var pinnableItemsRes = await queries.GetAllPinnableItems(login);
                if (pinnableItemsRes == null) return;

                foreach (var item in pinnableItemsRes)
                {
                    RepoButtonBlockViewModel viewModel = new()
                    {
                        Repository = item,
                        DisplayDetails = false,
                        DisplayStarButton = false,
                    };

                    _pinnableRepositories.Add(viewModel);
                }
            }
            else
            {
                foreach (var item in pinnedItemsRes)
                {
                    RepoButtonBlockViewModel viewModel = new()
                    {
                        Repository = item,
                        DisplayDetails = false,
                        DisplayStarButton = false,
                    };

                    _pinnedRepositories.Add(viewModel);
                }
            }
        }

        private async Task LoadUserAsync(string login)
        {
            UserQueries queries = new();
            var response = await queries.GetAsync(login);

            User = response ?? new();

            UserProfileOverviewViewModel = new()
            {
                User = User,
            };

            if (string.IsNullOrEmpty(User.WebsiteUrl) is false)
            {
                UserProfileOverviewViewModel.BuiltWebsiteUrl = new UriBuilder(User.WebsiteUrl).Uri;
            }
        }

        private void SetCurrentTabItem()
        {
            var provider = App.Current.Services;
            INavigationService navigationService = provider.GetRequiredService<INavigationService>();

            var currentItem = navigationService.TabView.SelectedItem.NavigationHistory.CurrentItem;
            currentItem.Header = $"{User?.Login}";
            currentItem.Description = $"{User?.Login}";
            currentItem.Icon = new muxc.ImageIconSource
            {
                ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/Icons/Profile.png"))
            };
        }

        private async Task ShowPinnedRepositoriesEditorDialogAsync()
        {
            var dialogs = new Uwp.Dialogs.EditPinnedRepositoriesDialog(Login);
            _ = await dialogs.ShowAsync();
        }
    }
}
