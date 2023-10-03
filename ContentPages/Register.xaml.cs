using DirectoryApp.ViewModels;

namespace DirectoryApp.ContentPages;

public partial class Register : ContentPage
{
	public Register()
	{
		InitializeComponent();
		BindingContext = new Register_ViewModel();
        Shell.Current.Title = "Register";
    }
}