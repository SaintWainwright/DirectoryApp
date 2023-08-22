namespace MyMAUIApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            Shell.Current.Title = "Login Page";
        }

        private void OnLoginClick(object sender, EventArgs e)
        {
            string adminUsername = "admin123";
            string adminPassword = "password123";

            if((string.IsNullOrEmpty(entryUsername.Text)) || (string.IsNullOrEmpty(entryPassword.Text)))
            {
                MessageDisplay.Text = "Username and/or Password should not be empty. Please try again.";
            }

            else if (adminUsername == entryUsername.Text && adminPassword == entryPassword.Text)
            {
                MessageDisplay.Text = "Login Successful";
            }
            else
            {
                MessageDisplay.Text = "Username and/or Password is incorrect. Please try again";
            }
        }
    }
}