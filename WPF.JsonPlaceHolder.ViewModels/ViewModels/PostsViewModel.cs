using System.Collections.ObjectModel;
using WPF.JsonPlaceHolder.Models;
using WPF.JsonPlaceHolder.ViewModels.Commands;
using WPF.JsonPlaceHolder.ViewModels.Contracts;
using WPF.JsonPlaceHolder.ViewModels.Http;

namespace WPF.JsonPlaceHolder.ViewModels.ViewModels;

public class PostsViewModel : ViewModelBase
{
	private readonly WPFHttpClient _httpClient;

	public ObservableCollection<Post> Posts { get; set; } = [];

	public ObservableCollection<Comment> Comments { get; set; } = [];

	public PostsViewModel()
	{
		_httpClient = WPFHttpClient.Instance;

		Refresh().ConfigureAwait(false);
	}

	private async Task Refresh()
	{
		await foreach (var post in GetPosts())
		{
			InsertIntoSortedCollection(Posts, (a, b) => b.Id.CompareTo(a.Id), post);
		}
	}

	private async IAsyncEnumerable<Post> GetPosts()
	{
		var posts = await _httpClient.GetRequest<IEnumerable<Post>>("https://jsonplaceholder.typicode.com/posts").ConfigureAwait(false);

		if (posts is not null)
			foreach (var post in posts)
			{
				yield return post;
			}
	}

	private async Task GetCommentsByPostId(int id)
	{
		Comments.Clear();

		var comments = await _httpClient.GetRequest<IEnumerable<Comment>>($"https://jsonplaceholder.typicode.com/posts/{id}/comments");

		if (comments is not null)
			foreach (var comment in comments)
			{
				InsertIntoSortedCollection(Comments, (a, b) => b.Id.CompareTo(a.Id), comment);
			}
	}

	public IAsyncCommand<int> GetPostComments => new AsyncCommand<int>(GetCommentsByPostId);
}
