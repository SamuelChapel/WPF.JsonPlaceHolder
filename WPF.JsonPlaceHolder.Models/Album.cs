using WPF.JsonPlaceHolder.Models.Base;

namespace WPF.JsonPlaceHolder.Models;

public class Album(int id, string title, int userId) : EntityBase<int>(id)
{
	public string Title { get; set; } = title;
	public int UserId { get; set; } = userId;
}
