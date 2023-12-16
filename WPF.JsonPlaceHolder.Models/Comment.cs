using WPF.JsonPlaceHolder.Models.Base;

namespace WPF.JsonPlaceHolder.Models;

public class Comment(int id, string name, string email, string body, int postId) : EntityBase<int>(id)
{
	public string Name { get; set; } = name;
	public string Email { get; set; } = email;
	public string Body { get; set; } = body;
	public int PostId { get; set; } = postId;
}
