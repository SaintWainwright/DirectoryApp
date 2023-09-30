using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DirectoryApp.ContentPages;
using System.Windows.Input;
using DirectoryApp.View;
using System.Collections.ObjectModel;

namespace DirectoryApp.ViewModels
{
    public partial class Register_ViewModel : MainViewModel
    {
        public Register_ViewModel()
        {
            NewStudent = new Student();
            InitializeSchoolPrograms();
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

        private DateTime _DateToday = DateTime.Today;
        public DateTime DateToday
        {
            get { return _DateToday; }
            set { _DateToday = value; }
        }

        private string _MobileNoEntry;
        public string MobileNoEntry
        {
            get { return _MobileNoEntry; }
            set
            {
                _MobileNoEntry = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(_MobileNoEntry));
                int intOnly;
                if ((int.TryParse(value, out intOnly)) || String.IsNullOrEmpty(_MobileNoEntry))
                {
                    NewStudent.MobileNo = intOnly.ToString();
                }
                else
                {
                    Application.Current.MainPage.DisplayAlert("Mobile No", "Number Input Only", "Okay");
                }
            }
        }

        private ObservableCollection<String> _SchoolProgram;
        private ObservableCollection<String> _Courses;
        private ObservableCollection<String> _YearLevel;

        public ObservableCollection<String> SchoolProgram
        {
            get { return  _SchoolProgram; }
            set
            {
                _SchoolProgram = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(_SchoolProgram));
            }
        }

        public ObservableCollection<String> Courses
        {
            get { return _Courses; }
            set
            {
                _Courses = value;
                OnPropertyChanged(nameof(_Courses));
            }
        }

        public ObservableCollection<String> YearLevel
        {
            get { return _YearLevel; }
            set
            {
                _YearLevel = value;
                OnPropertyChanged(nameof(_YearLevel));
            }
        }

        private void InitializeSchoolPrograms()
        {
            SchoolProgram = new ObservableCollection<string>
            {
                "-SELECT-",
                "School of Engineering",
                "School of Computer Science",
                "School of Arts and Sciences",
                "School of Business and Management",
                "School of Allied Medical Service",
                "School of Education",
                "School of Law",
            };
        }
        public void InitializeCourses()
        {
            Courses = new ObservableCollection<string>();
            if(SchoolProgramIndex == 1)
            {
                Courses.Add("Computer Engineering");
                Courses.Add("Civil Engineering");
                Courses.Add("Industrial Engineering");
                Courses.Add("Electrical Engineering");
                Courses.Add("Electronics Engineering");
                Courses.Add("Mechanical Engineering");
            }
            else if(SchoolProgramIndex == 2)
            {
                Courses.Add("Information Technology");
                Courses.Add("Computer Sciences");
                Courses.Add("Information Systems");
            }
        }
        public int _SchoolProgramIndex = 0;
        public int SchoolProgramIndex
        {
            get { return _SchoolProgramIndex; }
            set { _SchoolProgramIndex = value; OnPropertyChanged(); OnPropertyChanged(nameof(_SchoolProgramIndex));}
        }
    }
}
