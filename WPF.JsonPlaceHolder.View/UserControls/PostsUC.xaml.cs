using System.Windows.Controls;
using WPF.JsonPlaceHolder.ViewModels.ViewModels;

namespace WPF.JsonPlaceHolder.Views.UserControls;
/// <summary>
/// Interaction logic for PostsUS.xaml
/// </summary>
public partial class PostsUC : UserControl
{
	public PostsUC()
	{
		InitializeComponent();
		DataContext = new PostsViewModel();
	}
}
