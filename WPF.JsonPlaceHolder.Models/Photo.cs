namespace WPF.JsonPlaceHolder.Models;

public class Photo(int id, string title, string url, string thumbnailUrl) : EntityBase<int>(id)
{
	public string Title { get; } = title;
	public string Url { get; } = url;
	public string ThumbnailUrl { get; } = thumbnailUrl;
}
