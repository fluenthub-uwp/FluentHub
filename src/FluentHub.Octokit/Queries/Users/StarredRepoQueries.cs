﻿namespace FluentHub.Octokit.Queries.Users
{
	public class StarredRepoQueries
	{
		public async Task<OctokitQueryResult> GetAllAsync(
			string login,
			int? first = null,
			string? after = null,
			int? last = null,
			string? before = null,
			OctokitGraphQLModel.StarOrder? orderBy = null,
			bool? ownedByViewer = null)
		{
			OctokitGraphQLCore.Arg<IEnumerable<OctokitGraphQLModel.IssueState>> issueState =
				new(new OctokitGraphQLModel.IssueState[]
				{
					OctokitGraphQLModel.IssueState.Open
				});

			OctokitGraphQLCore.Arg<IEnumerable<OctokitGraphQLModel.PullRequestState>> pullRequestState =
				new(new OctokitGraphQLModel.PullRequestState[]
				{
					OctokitGraphQLModel.PullRequestState.Open
				});

			var query = new Query()
				.User(login)
				.StarredRepositories(
					first,
					after,
					last,
					before,
					orderBy,
					ownedByViewer)
				.Select(root => new RepositoryConnection
				{
					Edges = root.Edges.Select(x => new RepositoryEdge
					{
						Node = x.Node.Select(x => new Repository
						{
							Name = x.Name,
							Description = x.Description,
							StargazerCount = x.StargazerCount,
							ForkCount = x.ForkCount,
							IsFork = x.IsFork,
							IsInOrganization = x.IsInOrganization,
							ViewerHasStarred = x.ViewerHasStarred,
							UpdatedAt = x.UpdatedAt,
							UpdatedAtHumanized = x.UpdatedAt.Humanize(null, null),

							LicenseInfo = x.LicenseInfo.Select(licenseInfo => new License
							{
								Name = licenseInfo.Name,
							})
							.SingleOrDefault(),

							Issues = x.Issues(null, null, null, null, null, null, null, issueState).Select(issues => new IssueConnection
							{
								TotalCount = issues.TotalCount
							})
							.Single(),

							PullRequests = x.PullRequests(null, null, null, null, null, null, null, null, pullRequestState).Select(issues => new PullRequestConnection
							{
								TotalCount = issues.TotalCount
							})
							.Single(),

							Owner = x.Owner.Select(owner => new RepositoryOwner
							{
								AvatarUrl = owner.AvatarUrl(500),
								Id = owner.Id,
								Login = owner.Login,
							})
							.Single(),

							PrimaryLanguage = x.PrimaryLanguage.Select(y => new Language
							{
								Name = y.Name,
								Color = y.Color,
							})
							.SingleOrDefault(),
						}).Single()
					}).ToList(),

					PageInfo = new()
					{
						EndCursor = root.PageInfo.EndCursor,
						HasNextPage = root.PageInfo.HasNextPage,
						HasPreviousPage = root.PageInfo.HasPreviousPage,
						StartCursor = root.PageInfo.StartCursor,
					},
				})
				.Compile();

			var response = await App.Connection.Run(query);

			var result = new OctokitQueryResult()
			{
				PageInfo = response.PageInfo,
				Response = response.Edges.Select(x => x.Node).ToList(),
			};

			return result;
		}
	}
}
