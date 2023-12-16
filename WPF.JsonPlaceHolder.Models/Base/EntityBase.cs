namespace WPF.JsonPlaceHolder.Models.Base;

public abstract class EntityBase<TId>
{
	public TId Id { get; set; }

	protected EntityBase(TId id) => Id = id;
}
