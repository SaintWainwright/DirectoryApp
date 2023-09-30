using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DirectoryApp.ViewModels
{
    public partial class MainPage_ViewModel : MainViewModel
    {
        private string _txtUsername = string.Empty;
        public string txtUsername
        {
            get { return _txtUsername; }
            set
            {
                _txtUsername = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(_txtUsername));
            }
        }
        private string _txtPassword = string.Empty;
        public string txtPassword
        {
            get { return _txtPassword; }
            set
            {
                _txtPassword = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(_txtPassword));
            }
        }
        private string _MessageDisplay = string.Empty;
        public string MessageDisplay
        {
            get { return _MessageDisplay; }
            set
            {
                _MessageDisplay = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(_MessageDisplay));
            }
        }

        private void OnLogin()
        {
            string adminUsername = "admin123";
            string adminPassword = "password123";
            if ((string.IsNullOrEmpty(txtUsername)) || (string.IsNullOrEmpty(txtPassword)))
            {
                MessageDisplay = "Username and/or Password should not be empty. Please try again.";
            }

            else if (adminUsername == txtUsername && adminPassword == txtPassword)
            {
                MessageDisplay = "Login Successful";
            }
            else
            {
                MessageDisplay = "Username and/or Password is incorrect. Please try again";
            }
        }
        public ICommand OnLoginCommand => new Command(OnLogin);
    }
}
