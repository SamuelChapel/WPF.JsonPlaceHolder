using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Threading;

namespace WPF.JsonPlaceHolder.ViewModels.ViewModels;

public class ViewModelBase : INotifyPropertyChanged
{
	public event PropertyChangedEventHandler? PropertyChanged;

	protected void OnPropertyChanged(string name)
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
	}

	protected static void InsertIntoSortedCollection<T>(ObservableCollection<T> collection, Comparison<T> comparison, T modelToInsert)
	{
		if (collection.Count is 0)
		{
			collection.Add(modelToInsert);
		}
		else
		{
			int index = 0;
			foreach (var model in collection)
			{
				if (comparison(model, modelToInsert) >= 0)
				{
					collection.Insert(index, modelToInsert);
					return;
				}

				index++;
			}

			collection.Insert(index, modelToInsert);
		}
	}

	void ObservableCollectionCallback(IEnumerable collection, object context, Action accessMethod, bool writeAccess)
	{
		Dispatcher.CurrentDispatcher.Invoke(accessMethod);
	}
}
