using System.Windows.Input;

namespace WPF.JsonPlaceHolder.ViewModels.Contracts;

public interface IAsyncCommand : ICommand
{
	Task ExecuteAsync();
	bool CanExecute();
}

public interface IAsyncCommand<T> : ICommand
{
	Task ExecuteAsync(T parameter);
	bool CanExecute(T parameter);
}
