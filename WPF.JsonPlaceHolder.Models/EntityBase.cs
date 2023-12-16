namespace WPF.JsonPlaceHolder.Models;

public abstract class EntityBase<TId>
{
	public TId Id { get; set; }

	protected EntityBase(TId id) => Id = id;
}
