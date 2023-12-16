namespace WPF.JsonPlaceHolder.Models;

public class Post(int id, string title, string body, int userId) : EntityBase<int>(id)
{
	public string Title { get; set; } = title;
	public string Body { get; set; } = body;
	public int UserId { get; set; } = userId;
}
