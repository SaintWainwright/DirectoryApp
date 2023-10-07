using DirectoryApp.ViewModels;

namespace DirectoryApp.ContentPages;

public partial class AddContact : ContentPage
{
	public AddContact()
	{
		InitializeComponent();
		BindingContext = new AddContact_ViewModel();
        Shell.Current.Title = "Add Contact";
    }
}