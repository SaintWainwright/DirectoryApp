using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DirectoryApp.ContentPages;
using System.Windows.Input;
using DirectoryApp.View;

namespace DirectoryApp.ViewModels
{
    public partial class Register_ViewModel : MainViewModel
    {
        public Register_ViewModel()
        {
            NewStudent = new Student();
        }
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

        private string _StudentIDEntry;
        public string StudentIDEntry
        {
            get { return _StudentIDEntry; }
            set
            {
                _StudentIDEntry = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(_StudentIDEntry));
                int intOnly;
                if ((int.TryParse(value, out intOnly)) || String.IsNullOrEmpty(StudentIDEntry))
                {
                    NewStudent.StudentID = intOnly;
                }
                else
                {
                    Application.Current.MainPage.DisplayAlert("Student ID", "Required. Numeric values only", "Okay");
                }
            }
        }
    }
}
