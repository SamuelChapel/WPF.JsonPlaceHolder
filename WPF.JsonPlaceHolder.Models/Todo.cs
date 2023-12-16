namespace WPF.JsonPlaceHolder.Models;

public class Todo(int id, string title, bool completed, int userId) : EntityBase<int>(id)
{
	public string Title { get; } = title;
	public bool Completed { get; } = completed;
	public int UserId { get; } = userId;
}
