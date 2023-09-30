using DirectoryApp.ContentPages;
namespace DirectoryApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            //RegisterRouting
            Routing.RegisterRoute(nameof(Register), typeof(Register));
        }
    }
}