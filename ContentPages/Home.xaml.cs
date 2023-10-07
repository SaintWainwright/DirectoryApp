using DirectoryApp.ViewModels;
namespace DirectoryApp.ContentPages;

public partial class Home : ContentPage
{
	public Home()
	{
		InitializeComponent();
        BindingContext = new Home_ViewModel();
        Shell.Current.Title = "Home Page";
    }
}