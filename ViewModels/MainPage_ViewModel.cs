using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DirectoryApp.ContentPages;
using System.Windows.Input;
using DirectoryApp.Service;
using DirectoryApp.View;

namespace DirectoryApp.ViewModels
{
    public partial class MainPage_ViewModel : MainViewModel
    {
        private readonly StudentServices studentServices;
        private Student _NewStudent;
        public Student NewStudent
        {
            get { return _NewStudent; }
            set
            {
                _NewStudent = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(_NewStudent));
            }
        }
        public MainPage_ViewModel()
        {
            NewStudent = new Student(); 
            studentServices = new StudentServices();
        }
        private string _txtStudentID = string.Empty;
        public string txtStudentID
        {
            get { return _txtStudentID; }
            set
            {
                _txtStudentID = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(_txtStudentID));
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
            
            if ((string.IsNullOrEmpty(txtStudentID)) || (string.IsNullOrEmpty(txtPassword)))
            {
                MessageDisplay = "Username and/or Password should not be empty. Please try again.";
            }

            else if (AuthenticateLogin())
            {
                MessageDisplay = "Login Successful";
                string StudentID = NewStudent.StudentID;
                Shell.Current.GoToAsync($"{nameof(Home)}?id={StudentID}");
            }
            else
            {
                MessageDisplay = "Username and/or Password is incorrect. Please try again";
            }
        }
        public ICommand OnLoginCommand => new Command(OnLogin);

        private void OnNewUser()
        {
            Shell.Current.GoToAsync(nameof(Register));
        }
        public ICommand OnNewUserCommand => new Command(OnNewUser);
        private bool AuthenticateLogin()
        {
            bool exist = false;
            foreach (var studentListed in studentServices.GetStudents())
            {
                if (txtStudentID == studentListed.StudentID && txtPassword == studentListed.Password)
                {
                    NewStudent = studentListed;
                    exist = true;
                    
                }
            }
            return exist;
        }
    }
}
