using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DirectoryApp.View;

namespace DirectoryApp.ViewModels
{
    [QueryProperty(nameof(StudentID), "id")]
    public partial class Home_ViewModel : MainViewModel
    {
        private string studentID;
        public string StudentID 
        {
            get { return studentID; }
            set
            {
                studentID = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(studentID));
            }
        }
    }
}
