using DirectoryApp.ViewModels;
namespace DirectoryApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainPage_ViewModel();
            Shell.Current.Title = "Login Page";
        }
    }
}